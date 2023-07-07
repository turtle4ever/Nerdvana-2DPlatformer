using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Move_Spawn : MonoBehaviour
{
    private Vector2 laser_position;
    public float decreaseX;
    public float speed;
    void Start()
    {
        laser_position = Global.spawnpoint;
        laser_position.x -= decreaseX;
    }
    void Update()
    {
        laser_position.x += speed * Time.deltaTime;
    }
}
