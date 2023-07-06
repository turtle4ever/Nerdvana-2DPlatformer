using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings_start : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip clipcomp;
    [SerializeField] private AudioSource source;

    public void OnPointerDown(PointerEventData eventData)
    {
        source.PlayOneShot(clipcomp);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Time.timeScale = 1;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Hello");
        SceneManager.LoadScene("Settings");
    }
}
