using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static Unity.Burst.Intrinsics.X86;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    int flag=0;
    public float speed=0f;
    //public float Dspeed=100f;
    public float Aspeed_before_move=-100f;
    public float Dspeed_before_move=100f;
    public float gravity=3f;
    public float jump=-10f;
    int curjump=1;
    float falling=0f;
    public float fallingin=1f;
    public GameObject player;
    public float acceleration = 100f;
    public float AspeedCap = -400f;
    public float DspeedCap = 400f;
    public Rigidbody2D playermove;
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
       /* if (flag == 1)
        {

            if (lrspeed + Time.deltaTime * acceleration < speedCap)
            {
                lrspeed += (Time.deltaTime * acceleration);
            }
            else
            {
                lrspeed = speedCap;
            }
            playermove.velocity = new Vector2(0f, 0f);
            playermove.AddForce(new Vector2(Time.deltaTime * -lrspeed, 0f));
        }
        if (flag == 2)
        {
            playermove.velocity = new Vector2(0f,0f);
            playermove.AddForce(new Vector2(Time.deltaTime * lrspeed, 0f));
        }
      /*  if(Input.GetKeyDown(KeyCode.Space) && curjump==1)
        {
            gravity = jump;
        }
        gravity = gravity - Time.deltaTime * falling;
        player.transform.position += new Vector3(0f, Time.deltaTime * gravity, 0f); */

    }
   // float auxspeed=0f;
    private void FixedUpdate()
    {
        Debug.Log(speed + "asdjab");
        if (flag == 1)
        {

            if (speed - Time.fixedDeltaTime * acceleration > AspeedCap)
            {
                speed -= (Time.fixedDeltaTime * acceleration);
            }
            else
            {
                speed = AspeedCap;
            }
            Debug.Log(speed);
            playermove.velocity = new Vector2(0f, playermove.velocity.y);
            playermove.AddForce(new Vector2(speed, 0f));
        }
        if(speed > Dspeed_before_move && flag!=2)
        {
            if (speed - Time.fixedDeltaTime * acceleration > Dspeed_before_move)
            {
                speed -= (Time.fixedDeltaTime * acceleration);
                playermove.velocity = new Vector2(0f, playermove.velocity.y);
                playermove.AddForce(new Vector2(speed, 0f));
            }
            else
            {
                speed = Dspeed_before_move;
                playermove.velocity = new Vector2(0f, playermove.velocity.y);
            }
        }//////////////////////////////////////////////////////////////////movement part one ending
        if (flag == 2)
        {
            if (speed + Time.fixedDeltaTime * acceleration < DspeedCap)
            {
                speed += (Time.fixedDeltaTime * acceleration);
            }
            else
            {
                Debug.Log("cap");
                speed = DspeedCap;
            }
            Debug.Log(speed);
            playermove.velocity = new Vector2(0f, playermove.velocity.y);
            playermove.AddForce(new Vector2(speed, 0f));
        }
        if(speed < Aspeed_before_move && flag!=1)
        {
            if (speed + Time.fixedDeltaTime * acceleration < Aspeed_before_move)
            {
                speed += (Time.fixedDeltaTime * acceleration);
                playermove.velocity = new Vector2(0f, playermove.velocity.y);
                playermove.AddForce(new Vector2(speed, 0f));
            }
            else
            {
                speed = Aspeed_before_move;
                playermove.velocity = new Vector2(0f, playermove.velocity.y);
            }
        }//////////////////////////////////////////////////////////////////movement part 2 ending
    }
}
