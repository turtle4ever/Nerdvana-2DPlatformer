using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("kill them all");
        Time.timeScale = 1;
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
        Global.timeworks = false;
        SceneManager.LoadScene("Level2");
    }
}
