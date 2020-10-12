using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickedUp : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CrystalOre")
        {
            gameManager.amountCrystalOre++;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Gold")
        {
            gameManager.amountGold += 1000;
            Destroy(collision.gameObject);
        }
    }
}
