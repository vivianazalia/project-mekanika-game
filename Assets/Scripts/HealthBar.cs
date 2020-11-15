using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Health health;
    SpriteRenderer fillSprite;

    void Start()
    {
        fillSprite = transform.Find("Fill").Find("SpriteFill").GetComponent<SpriteRenderer>();
    }

    public void Setup(Health health)
    {
        this.health = health;
    }

    void Update()
    {
        transform.Find("Fill").localScale = new Vector3(health.GetHealthPercentage(), 1);
    }
}
