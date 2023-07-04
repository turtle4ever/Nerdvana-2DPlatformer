using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    int flag=0;
    public float lrspeed=4f;
    public float gravity=-6f;
    public float jump=10f;
    int curjump=1;
    float falling=0f;
    public float fallingin=3f;
    public GameObject player;
    public float acceleration = 1f;
    public float speedCap = 8f;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        gravity = 0f;
        falling = 0f;
        curjump = 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        curjump = 0;
        falling = fallingin;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            flag = 1;
        }
        if (Input.GetKeyUp(KeyCode.A) && flag==1)
        {
            flag = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            flag = 2;
        }
        if (Input.GetKeyUp(KeyCode.D) && flag==2)
        {
            flag = 0;
        }
        if (flag == 1)
        {
            if (lrspeed + Time.deltaTime * acceleration < speedCap)
            {
                lrspeed += (Time.deltaTime * acceleration);
            }
            else
            {
                lrspeed = speedCap;
            }
            player.transform.position += new Vector3(Time.deltaTime * -lrspeed, 0f, 0f);
        }
        if (flag == 2)
            player.transform.position += new Vector3(Time.deltaTime * lrspeed, 0f, 0f);
        if(Input.GetKeyDown(KeyCode.Space) && curjump==1)
        {
            gravity = jump;
        }
        gravity = gravity - Time.deltaTime * falling;
        player.transform.position += new Vector3(0f, Time.deltaTime * gravity, 0f);

    }
}
