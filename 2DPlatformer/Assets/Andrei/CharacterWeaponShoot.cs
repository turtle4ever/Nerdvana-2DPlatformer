using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponShoot : MonoBehaviour
{
    public float speed = 10;
    public GameObject bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().AddForce(bulletClone.transform.right * speed);
        }
    }
}
