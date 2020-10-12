using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public Slider playersHealth;
    public Image fillSlider;

    void Start()
    {
        playersHealth.maxValue = health;
    }

    void Update()
    {
        playersHealth.value = health;

        if (health < 50)
        {
            fillSlider.color = Color.yellow;
        }

        if (health < 25)
        {
            fillSlider.color = Color.red;
        }
    }
}
