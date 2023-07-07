using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Level21 : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("kill them all");
        Time.timeScale = 1;
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
        Global.timeworks = false;
        SceneManager.LoadScene("Level1");
    }
}
