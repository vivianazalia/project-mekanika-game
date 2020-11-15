using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public int critRate;
    public float bulletForce;

    public Transform bulletSpawn;
    public GameObject bullet;

    private bool hasShot = false;
    public bool isCooldown = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DoubleDamage();
        }
    }

    void Shoot()
    {
        if (!hasShot)
        {
            GameObject bulletRef = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody2D rbBullet = bulletRef.GetComponent<Rigidbody2D>();

            rbBullet.AddForce(bulletSpawn.up * bulletForce, ForceMode2D.Impulse);

            hasShot = true;

            StartCoroutine(DelayShot());
        }
    }

    public void DoubleDamage()
    {
        if (!isCooldown)
        {
            damage *= 2;

            StartCoroutine(CooldownDoubleDamage());
        }
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(0.3f);

        hasShot = false;
    }

    IEnumerator CooldownDoubleDamage()
    {
        yield return new WaitForSeconds(2);

        isCooldown = true;
        damage /= 2;

        yield return new WaitForSeconds(5);

        isCooldown = false;
    }
}
