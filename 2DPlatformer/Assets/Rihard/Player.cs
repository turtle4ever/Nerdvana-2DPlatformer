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
    public int flag=0,isslide=0;
    int jump = 0;
    public LayerMask groundmask;
    public GameObject playerfootleft;
    public GameObject playerfootright;
   // public GameObject player;
    public Rigidbody2D playermove;
    public BoxCollider2D colider;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Global.timeworks == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                flag = 1;
            }
            if (Input.GetKeyUp(KeyCode.A) && flag == 1)
            {
                flag = 0;
               // GetComponent<Animator>().SetBool("iswalking", false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            { 
                flag = 2;
            }
            if (Input.GetKeyUp(KeyCode.D) && flag == 2)
            {
                flag = 0;
                //GetComponent<Animator>().SetBool("iswalking", false);
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                isslide = 1;
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                isslide = 0;
                crouch_check = 0;
            }
            if(flag==0)
            {
                if (isslide == 1)
                    crouch_check = 1;
                GetComponent<Animator>().SetBool("iswalking", false);
            }
            if(flag==1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetBool("iswalking", true);
            }
            if(flag==2)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetBool("iswalking", true);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Animation>().GetClip("jumping");
                jump = 1;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jump = 0;
            }
        }
    }
    public float inspeedD=8.9f,curspeedD=9f,acc=0.2f,inspeedA=-8.9f,curspeedA=-9f,maxspeedA=-30f,maxspeedD=30f,above_cast=2f;
    int prevflag=0;

    public float jump_f=10f,grav=3f,dist_To_ground=0.02f,slideslow=-0.5f,slideslowin=-0.5f,slideslowinNoKey=0.5f,crouch_speed=1f,up=0.2f;
    public int isground = 0,crouch_check=0,ishead=0,crouch_check2=0;
    private void FixedUpdate()
    {

        if (Global.timeworks == false)
        {
            isground = 0;
            ishead = 0;
            crouch_check2 = 0;
            Vector2 first_ray = playerfootleft.transform.position;
            Vector2 last_ray = playerfootright.transform.position;
            for (float i = first_ray.x; i < last_ray.x; i += 0.05f)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(i, first_ray.y), new Vector2(0, -1), 1f, groundmask);
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(i, first_ray.y+up), new Vector2(0, 1), above_cast, groundmask);
                Debug.Log(hit2.collider + " " + hit2.point, hit2.collider);
                Debug.DrawRay(new Vector2(i, first_ray.y), new Vector2(0, -1), Color.green, 1f);
                Debug.DrawRay(new Vector2(i, first_ray.y+up), new Vector2(0, above_cast), Color.red, 1f);
                Debug.Log(Mathf.Abs(first_ray.y) + "chestie pamant");
                if (hit.collider!=null && Mathf.Abs(hit.point.y - first_ray.y) < dist_To_ground)
                {
                    isground = 1;
                }
                if (hit2.collider!=null && Mathf.Abs(hit2.point.y - (first_ray.y+up)) < above_cast)
                {
                    ishead = 1;
                }
            }
            if (isground == 1 && ishead == 1 && isslide==0)
            {
                crouch_check2 = 1;
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
            if (crouch_check == 0 && crouch_check2==0)
            {
                if (isslide == 1)
                {
                    colider.size = new Vector2(0.85f, 0.2f);
                    if (flag == 2)
                        colider.offset = new Vector2(-0.2f, -0.4f);
                    else
                        colider.offset = new Vector2(0.2f, -0.4f);
                }
                else
                {
                    colider.size = new Vector2(0.2f, 0.85f);
                    colider.offset = new Vector2(-0.05f, -0.078f);
                }
                if (jump == 1 && isground == 1)
                {
                    Debug.Log("jump");
                    playermove.velocity = (new Vector2(0, jump_f));
                    // playermove.gravityScale = grav;
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////Movement left right
                //if (isslide == 1)
                //      flag = 0;
                if (flag == 0)
                {
                    if (isslide == 1)
                    {
                        slideslow = slideslowinNoKey;
                    }
                    else
                    {
                        slideslow = 1f;
                    }
                    if (prevflag == 1)
                    {
                        if (curspeedA < inspeedA)
                        {
                            curspeedA += acc * 2f * slideslow;
                            playermove.velocity = new Vector2(curspeedA - inspeedA, playermove.velocity.y);
                        }
                        else
                        {
                            if (isslide == 1)
                                crouch_check = 1;
                            curspeedA = inspeedA - 0.1f;
                            playermove.velocity = new Vector2(0, playermove.velocity.y);
                            prevflag = 0;
                        }
                        Debug.Log(curspeedA);
                    }
                    if (prevflag == 2)
                    {
                        if (curspeedD > inspeedD)
                        {
                            curspeedD -= acc * 2f * slideslow;
                            playermove.velocity = new Vector2(curspeedD - inspeedD, playermove.velocity.y);
                        }
                        else
                        {
                            if (isslide == 1)
                                crouch_check = 1;
                            curspeedD = inspeedD + 0.1f;
                            playermove.velocity = new Vector2(0, playermove.velocity.y);
                            prevflag = 0;
                        }
                    }
                }
                if (flag == 1)
                {
                    if (isslide == 1)/////////////////////////////////////////////////////////////////
                    {
                        slideslow = slideslowin;
                    }
                    else
                    {
                        slideslow = 1f;
                    }/////////////////////////////////////////////////////////////////////////////
                    if (prevflag == 0)
                    {
                        prevflag = 1;
                    }
                    if (prevflag == 1)
                    {
                        if (curspeedA < inspeedA)
                        {
                            curspeedA -= acc * slideslow;
                            curspeedA = Mathf.Max(curspeedA, maxspeedA);
                        }
                        else
                        {
                            crouch_check = 1;
                            curspeedA = inspeedA - 0.1f;
                        }
                        Debug.Log(curspeedA + " 1");
                        //  playermove.velocity = new Vector2(curspeedA - inspeedA, playermove.velocity.y);
                    }
                    if (prevflag == 2)
                    {

                        curspeedD = inspeedD + 0.1f;
                        playermove.velocity = new Vector2(0, playermove.velocity.y);
                        prevflag = 1;
                        Debug.Log(curspeedD + " 1 2");
                    }
                    playermove.velocity = new Vector2(curspeedA, playermove.velocity.y);
                }
                if (flag == 2)
                {
                    if (isslide == 1)/////////////////////////////////////////////////////////////////
                    {
                        slideslow = slideslowin;
                    }
                    else
                    {
                        slideslow = 1f;
                    }/////////////////////////////////////////////////////////////////////////////
                    if (prevflag == 0)
                    {
                        prevflag = 2;
                    }
                    if (prevflag == 2)
                    {
                        if (curspeedD > inspeedD)
                        {
                            curspeedD += acc * slideslow;
                            curspeedD = Mathf.Min(curspeedD, maxspeedD);
                        }
                        else
                        {
                            crouch_check = 1;
                            curspeedD = inspeedD + 0.1f;
                        }
                        Debug.Log(curspeedD + " 2");
                        //  playermove.velocity = new Vector2(curspeedD-inspeedD, playermove.velocity.y);
                    }
                    if (prevflag == 1)
                    {
                        curspeedA = inspeedA - 0.1f;
                        prevflag = 2;
                        playermove.velocity = new Vector2(0f, playermove.velocity.y);
                        Debug.Log(curspeedA + " 2 2");

                    }
                    playermove.velocity = new Vector2(curspeedD, playermove.velocity.y);
                }
                
                    ///////////////////////////////////////////////////////////////////////////////////////////end of movement
            }
            else
            {
                colider.size = new Vector2(0.2f, 0.2f);
                colider.offset = new Vector2(-0.05f, -0.4f);
                if (flag == 0)
                {
                    playermove.velocity = new Vector2(0f,playermove.velocity.y);
                }
                if (flag == 1)
                {
                    playermove.velocity = new Vector2(-crouch_speed, playermove.velocity.y);
                }
                if (flag == 2)
                {
                    playermove.velocity = new Vector2(crouch_speed, playermove.velocity.y);
                }
            }
        }
    }
}
