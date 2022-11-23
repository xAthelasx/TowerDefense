using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Necesario para detectar interactuación con la UI.

public abstract class TradeCupcakeTower : MonoBehaviour, IPointerClickHandler
{
    protected static SugarMeterScript sugarMeter; //Medidor de azucar para saber cuantos puntos para gastar tengo.
    protected static TowerScript currentActiveTower; //Torreta seleccionada actualmente.

    private void Start()
    {
        if(sugarMeter == null) { sugarMeter = FindObjectOfType<SugarMeterScript>(); }
    }

    public static void SetActiveTower(TowerScript newCupcakeTower)
    {
        currentActiveTower = newCupcakeTower;
    }

    /// <summary>
    /// Función abstracta que sera llamada cuando uno de los tres botones se pulsen.
    /// </summary>
    public abstract void OnPointerClick(PointerEventData eventData);

}
