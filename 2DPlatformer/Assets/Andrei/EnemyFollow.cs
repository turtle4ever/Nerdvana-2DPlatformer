using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public LayerMask layer;
    public EnemyGunFollow gunFollow;

    private GameObject player;

    public bool CanSeePlayer()
    {
        return player != null && CanSeeObject(player);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = null;
        }
    }

    private void Update()
    {
        if (Global.timeworks == false)
        {
            if (CanSeePlayer())
            {
                gunFollow.FollowPlayer(player);

                if (player.transform.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
    }

    bool CanSeeObject(GameObject gameObject)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (gameObject.transform.position - transform.position).normalized, 100.0f, layer);
        Debug.DrawRay(transform.position, (gameObject.transform.position - transform.position).normalized * 100.0f, Color.cyan, 1);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
