using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerSell : TradeCupcakeTower
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (currentActiveTower == null) { return; }

        int sellingPrice = currentActiveTower.sellCost;
        sugarMeter.AddSugar(sellingPrice);
        Destroy(currentActiveTower.gameObject);
    }
}
