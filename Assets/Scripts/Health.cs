using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health 
{
    private float health;
    private float maxHealth;
    private Color color;
    private SpriteRenderer imageFill;

    public Health(int healthValue)
    {
        this.maxHealth = healthValue;
        health = maxHealth;
    }

    public Health(int healthValue, SpriteRenderer imageFill)
    {
        this.maxHealth = healthValue;
        health = maxHealth;
        this.imageFill = imageFill;
    }

    public float GetHealthPercentage()
    {
        return health / maxHealth;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
    }

    public Color SetColor(Color color)
    {
        this.color = color;
        return this.color;
    }

    public void GetColor()
    {
        if(health < maxHealth / 2)
        {
            imageFill.color = SetColor(Color.yellow);
        }
        
        if(health < maxHealth / 4)
        {
            imageFill.color = SetColor(Color.red);
        }

        if(health <= 0)
        {
            health = 0;
        }
    }

    public float GetMaxHealth()
    {
        health = maxHealth;
        imageFill.color = SetColor(Color.green);
        return health;
    }
}
