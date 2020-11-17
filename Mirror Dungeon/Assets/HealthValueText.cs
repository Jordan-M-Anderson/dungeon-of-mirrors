using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthValueText : MonoBehaviour
{
    public Slider slider;
    public Text healthText;
    
    public void updateHealth()
    {
        healthText.text = slider.value.ToString() + "/3";
    }
}
