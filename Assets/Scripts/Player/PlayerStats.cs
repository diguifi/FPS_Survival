using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image healthStats, staminaStats;
    [SerializeField]
    private Text points;
    [SerializeField]
    private DayNightManager dayNightManager;

    public void DisplayHealthStats(float healthValue)
    {
        healthValue /= 100f;
        healthStats.fillAmount = healthValue;
    }

    public void DisplayStaminaStats(float staminaValue)
    {
        staminaValue /= 100f;
        staminaStats.fillAmount = staminaValue;
    }

    public void DisplayPoints()
    {
        points.gameObject.SetActive(true);
        points.text = $"Survived {dayNightManager.dayNumber} days";
    }
}
