using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyFollow enemyFollow;

    public float speed = 10;
    public GameObject bullet;

    public float cooldown;

    float timer;

    private void Update()
    {
        if (enemyFollow.CanSeePlayer())
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
                Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().AddForce(bulletClone.transform.right * speed);
        timer = 0;
    }
}
