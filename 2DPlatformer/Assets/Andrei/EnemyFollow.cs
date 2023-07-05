using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && CanSeeObject(collision.gameObject))
        {
            Debug.Log("Player entered aggro range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited aggro range");
        }
    }

    bool CanSeeObject(GameObject gameObject)
    {
        return true;
    }
}
