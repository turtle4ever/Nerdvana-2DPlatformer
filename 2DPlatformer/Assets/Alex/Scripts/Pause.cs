using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject Button,Button1,Button2;
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Global.timeworks == false)
            {
                Global.timeworks = true;
                Button.SetActive(true);
                Button2.SetActive(true);
                Button1.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Global.timeworks = false;
                Button.SetActive(false);
                Button1.SetActive(false);
                Button2.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }
}
