using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public void RespawnOnClick()
    {
        player.transform.position = Global.spawnpoint;
    }
}
