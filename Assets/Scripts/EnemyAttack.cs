using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    private float distance;
    private bool isAttack = false;
    private GameObject target;
    private PlayerHealth targetHealth;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        targetHealth = target.GetComponent<PlayerHealth>();

        StartCoroutine(Attack());
    }

    void Update()
    {
        distance = Mathf.Abs((transform.position - target.transform.position).magnitude);

        if (distance < 3 && isAttack)
        {
            targetHealth.health -= damage;
            isAttack = false;

            StartCoroutine(Attack());
        }
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);

        isAttack = true;
    }
}
