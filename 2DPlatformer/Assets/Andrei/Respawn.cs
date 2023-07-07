using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public void RespawnOnClick()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = Global.spawnpoint;
    }
}
