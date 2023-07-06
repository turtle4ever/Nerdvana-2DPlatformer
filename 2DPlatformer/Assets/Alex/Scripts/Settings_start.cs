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
        StartCoroutine(waiter());
        SceneManager.LoadScene("Settings");
    }

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(1);
    }
}
