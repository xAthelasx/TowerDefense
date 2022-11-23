using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerUpgrade : TradeCupcakeTower
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        //Comprobamos si hay torreta seleccionada.
        if(currentActiveTower == null) { return; }

        int upgradePrice = currentActiveTower.upgradeCost;
        if(currentActiveTower.isUpgradable && upgradePrice <= sugarMeter.GetSugarScore())
        {
            sugarMeter.AddSugar(-upgradePrice);
            currentActiveTower.UpgradeTower();

        }
    }
}
