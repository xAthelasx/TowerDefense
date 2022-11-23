using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCupcakeTower : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //Conocer las coordenadas del ratón.
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = 7.0f;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));

        if (Input.GetMouseButtonDown(0) && gameManager.IsPointerOnAllowedArea())
        {
            GetComponent<TowerScript>().enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            Destroy(this);
        }
    }
}
