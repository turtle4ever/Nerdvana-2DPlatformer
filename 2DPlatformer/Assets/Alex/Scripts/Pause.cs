using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
       

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(1);
    }
}
