using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MENU_PLAY : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        SceneManager.LoadScene("Level1");
    }   

    IEnumerator waiter()
    {
        
        yield return new WaitForSeconds(1);
    }
}