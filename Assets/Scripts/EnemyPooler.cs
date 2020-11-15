using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler Instance;

    [SerializeField]
    private EnemyHealth prefab;

    private Queue<EnemyHealth> queueEnemy;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        queueEnemy = new Queue<EnemyHealth>();
    }

    public EnemyHealth GetObject()
    {
        if (queueEnemy.Count == 0)
        {
            return AddObject();
        }

        return queueEnemy.Dequeue();
    }

    private EnemyHealth AddObject()
    {
        EnemyHealth enemy = Instantiate(prefab);
        return enemy;
    }

    public void ReturnToQueue(EnemyHealth enemy)
    {
        queueEnemy.Enqueue(enemy);
    }

    public int GetCount()
    {
        return queueEnemy.Count;
    }
}
