using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    Health enemyHealth;

    private PlayerAttack damageAtk;
    public int health = 100;

    public Slider sliderHealth;
    public Image fillSlider;

    SpriteRenderer fillBar;

    void Start()
    {
        damageAtk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        fillBar = transform.Find("HealthBar").Find("Fill").Find("SpriteFill").GetComponent<SpriteRenderer>();

        enemyHealth = new Health(health, fillBar);

        healthBar.Setup(enemyHealth);

        //sliderHealth.maxValue = health;
    }

    void Update()
    {
        //sliderHealth.value = health;

        /*if(health < 50)
        {
            fillSlider.color = Color.yellow;
        }

        if(health < 25)
        {
            fillSlider.color = Color.red;
        }*/

        enemyHealth.GetColor();
        Debug.Log(enemyHealth.GetHealthPercentage());

        if (enemyHealth.GetHealthPercentage() <= 0)
        {
            EnemyPooler.Instance.ReturnToQueue(this);
            gameObject.SetActive(false);
            Debug.Log(EnemyPooler.Instance.GetCount());
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemyHealth.GetDamage(damageAtk.damage);
            //health -= damageAtk.damage;
        }
    }
}
