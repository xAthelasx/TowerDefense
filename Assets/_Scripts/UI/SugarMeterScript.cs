using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarMeterScript : MonoBehaviour
{
    //Variable que indica donde se mostraran los puntos.
    private Text sugarMeter;
    //Variable que guarda el número de puntos
    private int sugarScore;

    private void Start()
    {
        sugarMeter = GetComponent<Text>();
        UpdateSugarMeter();
        AddSugar(50);
    }

    public int GetSugarScore()
    {
        return sugarScore;
    }

    public void AddSugar(int sugar)
    {
        sugarScore += sugar;

        if (sugarScore < 0) { sugarScore = 0; }

        UpdateSugarMeter();
    }

    void UpdateSugarMeter()
    {
        sugarMeter.text = sugarScore.ToString();
    }
}
