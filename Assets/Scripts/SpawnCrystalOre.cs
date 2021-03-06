﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrystalOre : MonoBehaviour
{
    public GameObject crystalOre;
    private bool isSpawn = false;

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
            CrystalOre crystalOreObj = ObjectPooler.Instance.GetObject();
            crystalOreObj.transform.position = pos;
            crystalOreObj.gameObject.SetActive(true);
            isSpawn = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        isSpawn = false;
    }
}
