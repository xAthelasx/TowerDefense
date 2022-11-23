using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //La variable waypoints es una lista que contiene posiciones en el mapa.
    public Waypoint firstWaypoint;

    //Variable booleana para saber si el ratón ser halla sobre una zona donde poder poner torretas.
    private bool isPointerOnAllowedArea = true;
    public bool IsPointerOnAllowedArea()
    {
        return isPointerOnAllowedArea;
    }

    private void OnMouseEnter()
    {
        isPointerOnAllowedArea = true;
    }
    private void OnMouseExit()
    {
        isPointerOnAllowedArea = false;
    }

    /////////////
    //GAME OVER//
    /////////////
    [Header("Pantallas de Game Over")]
    public GameObject winingScreen;
    public GameObject losingScreen;

    private HealthBarScript playerHealth;
    private int numberOfPandasToDefeat;

    private Transform spawnPoint; //Variable para saber donde spawnear los pandas.
    public GameObject pandaPrefab; //Prefab del panda.
    public int numberOfWaves; //Número de oleadas.
    public int numberOfPandasPerWave; //Numero de pandas por oleada.

    private static SugarMeterScript sugarMeterScript;

    private void Start()
    {
        playerHealth = FindObjectOfType<HealthBarScript>();
        spawnPoint = GameObject.Find("SpawningPoint").transform;
        if (sugarMeterScript == null) { sugarMeterScript = FindObjectOfType<SugarMeterScript>(); }

        StartCoroutine(WavesSpawner());
    }

    private void GameOver (bool playerHasWon)
    {
        if (playerHasWon) { winingScreen.SetActive(true); }
        else { losingScreen.SetActive(true); }

        Time.timeScale = 0;
    }

    public void OneMorePandaInHell()
    {
        numberOfPandasToDefeat--;
        sugarMeterScript.AddSugar(5);
    }

    public void BiteTheCake(int damage)
    {
        bool isCakeAllEaten = playerHealth.ApplyDamage(damage);

        if (isCakeAllEaten) { GameOver(false); }
        
        OneMorePandaInHell();
    }

    private IEnumerator WavesSpawner()
    {
        for (int i = 0; i<numberOfWaves; i++)
        {
            yield return PandaSpawner();

            numberOfPandasPerWave += 3;
        }

        GameOver(true);
    }

    private IEnumerator PandaSpawner()
    {
        numberOfPandasToDefeat = numberOfPandasPerWave;

        for(int i =0; i < numberOfPandasPerWave; i++)
        {
            Instantiate(pandaPrefab, spawnPoint.position, Quaternion.identity);
            float ratio = (i * 1.0f)/ (numberOfPandasPerWave - 1);
            float timeToWait = Mathf.Lerp(3f, 5f, ratio) + Random.Range(0f, 2f);
            yield return new WaitForSeconds(timeToWait);
        }

        yield return new WaitUntil(() => numberOfPandasToDefeat <= 0);
    }
}
