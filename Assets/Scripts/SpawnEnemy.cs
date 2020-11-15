using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private EnemyHealth health;
    Health enemyHealth;

    public GameObject enemy;
    private bool isSpawn = false;

    private void Start()
    {
        
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        float randomX = Random.Range(-10, 10);
        float randomY = Random.Range(-3.67f, 3);
        Vector2 pos = new Vector2(randomX, randomY);

        if (!isSpawn)
        {
            EnemyHealth enemyObj = EnemyPooler.Instance.GetObject();
            enemyObj.transform.position = pos;
            enemyObj.gameObject.SetActive(true);
            isSpawn = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
        isSpawn = false;
    }
}
