using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public PlayerAttack damageAtk;
    public int health = 100;

    public Slider sliderHealth;
    public Image fillSlider;

    void Start()
    {
        sliderHealth.maxValue = health;
    }

    void Update()
    {
        sliderHealth.value = health;

        if(health < 50)
        {
            fillSlider.color = Color.yellow;
        }

        if(health < 25)
        {
            fillSlider.color = Color.red;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= damageAtk.damage;
        }
    }
}
