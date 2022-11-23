using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [Tooltip("Vida máxima que tendrá el jugador")]
    public int maxHealth;
    //Imagen de la barra de vida.
    private Image fillingImage;
    //Vida actual del jugador.
    private int currentHealth;

    private void Start()
    {
        fillingImage = GetComponent<Image>();
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    public bool ApplyDamage(int damage)
    {
        //Aplicar el daño al a vida actual
        currentHealth -= damage;
        //Si aun me queda vida tengo que actualizar la vida actual.
        if (currentHealth > 0)
        {
            UpdateHealthBar();
            return false;
        }

        //Si llego a esta linea es que  no me queda vida.

        currentHealth = 0;
        UpdateHealthBar();
        return true;
    }

    void UpdateHealthBar()
    {
        //Calculo el porcentaje de vida que me queda.
        float percentage = currentHealth * 1.0f / maxHealth;
        //Aplico el porcentaje de relleno a la barra de vida.
        fillingImage.fillAmount = percentage;
    }

}
