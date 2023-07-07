using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAndDeathbound : MonoBehaviour
{
    void Start()
    {
        Global.spawnpoint = gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            Global.spawnpoint = collision.gameObject.transform.position;
        }
        if(collision.tag == "DeathBound")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.transform.position = Global.spawnpoint;
        }
    }
}
