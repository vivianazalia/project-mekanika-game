using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalOre : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.amountCrystalOre++;
            gameObject.SetActive(false);
            ObjectPooler.Instance.ReturnToQueue(this);
        }
    }
}
