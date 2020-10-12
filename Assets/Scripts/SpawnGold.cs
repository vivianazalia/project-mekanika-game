using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGold : MonoBehaviour
{
    public GameObject gold;
    private bool isSpawn = false;

    void Start()
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
            Instantiate(gold, pos, Quaternion.identity);
            isSpawn = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        isSpawn = false;
    }
}
