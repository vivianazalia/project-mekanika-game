using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField]
    private CrystalOre prefab;

    private Queue<CrystalOre> queueCrystalOre;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        queueCrystalOre = new Queue<CrystalOre>();   
    }

    public CrystalOre GetObject()
    {
        if(queueCrystalOre.Count == 0)
        {
            return AddObject();
        }

        return queueCrystalOre.Dequeue();
    }

    private CrystalOre AddObject()
    {
        CrystalOre crystalOre = Instantiate(prefab);
        return crystalOre;
    }

    public void ReturnToQueue(CrystalOre crystalOre)
    {
        queueCrystalOre.Enqueue(crystalOre);
    }
}
