using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void SetMaxHealthBar(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealthBar(float health)
    {
        slider.value = health;
    }
}
