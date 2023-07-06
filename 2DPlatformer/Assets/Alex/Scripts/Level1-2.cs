using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    [SerializeField] private AudioClip clipcomp;
    [SerializeField] private AudioSource source;

    public void OnTriggerEnter2D(Collision2D other)
    {
        Time.timeScale = 1;
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level2");
    }
}
