using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private bool playerApproach = false;

    Vector2 dir;
    Rigidbody2D rbEnemy;
    Transform target;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        dir = target.position - transform.position;

        if (playerApproach)
        {
            rbEnemy.MovePosition((Vector2)transform.position + dir.normalized * speed * Time.deltaTime);
        }

        if(dir.magnitude > 10)
        {
            playerApproach = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerApproach = true;
        }
    }


}
