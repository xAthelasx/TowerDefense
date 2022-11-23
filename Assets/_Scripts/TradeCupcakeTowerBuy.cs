using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerBuy : TradeCupcakeTower
{
    [Tooltip("Variable para identificar el prefab de la torreta que debemos instanciar con este botón.")]
    public GameObject cupcakeTowerPrefab;

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Recuperamos el precio de crear una torreta.
        int price = cupcakeTowerPrefab.GetComponent<TowerScript>().initialCost;
        if (price <= sugarMeter.GetSugarScore())
        {
            sugarMeter.AddSugar(-price);
            GameObject newTower = Instantiate(cupcakeTowerPrefab);
            currentActiveTower = newTower.GetComponent<TowerScript>();
        }
    }
}
