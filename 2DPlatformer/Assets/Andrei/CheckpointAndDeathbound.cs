using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAndDeathbound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            Global.spawnpoint = collision.gameObject.transform.position;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if(collision.tag == "DeathBound")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.transform.position = Global.spawnpoint;
        }
    }
}
