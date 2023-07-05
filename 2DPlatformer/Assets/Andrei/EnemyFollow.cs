using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public LayerMask layer;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            Debug.Log("Player entered aggro range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = null;
            Debug.Log("Player exited aggro range");
        }
    }

    private void Update()
    {
        if (player != null && CanSeeObject(player))
        {

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
