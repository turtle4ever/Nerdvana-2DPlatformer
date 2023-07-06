using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static Unity.Burst.Intrinsics.X86;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    int flag=0;
    int jump = 0;
    public LayerMask groundmask;
    public GameObject playerfootleft;
    public GameObject playerfootright;
    public Rigidbody2D playermove;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            flag = 1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("iswalking", true);
        }
        if (Input.GetKeyUp(KeyCode.A) && flag==1)
        {
            flag = 0;
            GetComponent<Animator>().SetBool("iswalking", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            flag = 2;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("iswalking", true);
        }
        if (Input.GetKeyUp(KeyCode.D) && flag==2)
        {
            flag = 0;
            GetComponent<Animator>().SetBool("iswalking", false);
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            jump = 1;
        }      
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            jump = 0;
        }
    }
    public float inspeedD=8.9f,curspeedD=9f,acc=0.2f,inspeedA=-8.9f,curspeedA=-9f,maxspeedA=-30f,maxspeedD=30f;
    int prevflag=0;

    public float jump_f=10f,grav=3f,dist_To_ground=0.02f;
    int isground = 0,isslope=0;
    private void FixedUpdate()
    {
        
        
        isground = 0;
        Vector2 first_ray = playerfootleft.transform.position;
        Vector2 last_ray = playerfootright.transform.position;
        for (float i = first_ray.x; i < last_ray.x; i += 0.05f)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(i, first_ray.y), new Vector2(0, -1), 1,groundmask);
            Debug.DrawRay(new Vector2(i, first_ray.y), new Vector2(0, -1), Color.green,100f);
            Debug.Log(Mathf.Abs(first_ray.y-hit.point.y) + "chestie pamant");
            if (Mathf.Abs(hit.point.y - first_ray.y) < dist_To_ground)
            {
                isground = 1;
            }
        }
        if (isground == 1)
        {
            //playermove.velocity = new Vector2(5f, 5f);
            Debug.Log("it is indeed on ground");
            playermove.gravityScale = 0;
        }
        else
        {
            Debug.Log("nuh-uh on ground");
            playermove.gravityScale = grav;
        }
        if (jump==1 && isground==1)
        {
            Debug.Log("jump");
            playermove.velocity=(new Vector2(0, jump_f));
           // playermove.gravityScale = grav;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////Movement left right
        if(flag==0)
        {
            if (prevflag == 1)
            {
                if (curspeedA < inspeedA)
                {
                    curspeedA += acc * 2f;
                    playermove.velocity = new Vector2(curspeedA - inspeedA, playermove.velocity.y);
                }
                else
                {
                    curspeedA = inspeedA-0.1f;
                    playermove.velocity = new Vector2(0, playermove.velocity.y);
                    prevflag = 0;
                }
                Debug.Log(curspeedA);
            }
            if(prevflag == 2) 
            {
                if (curspeedD > inspeedD)
                {
                    curspeedD -= acc * 2f;
                    playermove.velocity = new Vector2(curspeedD - inspeedD, playermove.velocity.y);
                }
                else
                {
                    curspeedD = inspeedD + 0.1f;
                    playermove.velocity = new Vector2(0, playermove.velocity.y);
                    prevflag = 0;
                }
            }
        }
        if(flag==1)
        {
            if(prevflag==0)
            {
                prevflag = 1;
            }
            if (prevflag == 1)
            {
                if (curspeedA < inspeedA)
                {
                    curspeedA -= acc;
                    curspeedA = Mathf.Max(curspeedA, maxspeedA);
                }
                Debug.Log(curspeedA + " 1");
              //  playermove.velocity = new Vector2(curspeedA - inspeedA, playermove.velocity.y);
            }
            if (prevflag == 2)
            {
                if (curspeedD > inspeedD)
                {
                    curspeedD -= acc * 2f;
                    playermove.velocity = new Vector2(curspeedD - inspeedD, playermove.velocity.y);
                }
                else
                {
                    curspeedD = inspeedD + 0.1f;
                    playermove.velocity = new Vector2(0, playermove.velocity.y);
                    prevflag = 1;
                }
                Debug.Log(curspeedD + " 1 2");
            }
            playermove.velocity=new Vector2(curspeedA, playermove.velocity.y);
        }
        if(flag==2)
        {
            if (prevflag == 0)
            {
                prevflag = 2;
            }
            if (prevflag == 2)
            {
                if (curspeedD > inspeedD)
                {
                    curspeedD += acc;
                    curspeedD = Mathf.Min(curspeedD, maxspeedD);
                }
                Debug.Log(curspeedD + " 2");
              //  playermove.velocity = new Vector2(curspeedD-inspeedD, playermove.velocity.y);
            }
            if (prevflag == 1)
            {
                if (curspeedA < inspeedA)
                {
                    curspeedA += acc * 2f;
                    playermove.velocity = new Vector2(curspeedA - inspeedA, playermove.velocity.y);
                }
                else
                {
                    curspeedA = inspeedA - 0.1f;
                    prevflag = 2;
                    playermove.velocity = new Vector2(0f, playermove.velocity.y);
                }
                Debug.Log(curspeedA + " 2 2");
                
            }
            playermove.velocity = new Vector2(curspeedD, playermove.velocity.y);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////end of movement
        
    }
}
