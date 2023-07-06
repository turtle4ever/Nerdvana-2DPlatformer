using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouseFollow : MonoBehaviour
{
    void Update()
    {
        if (Global.timeworks == false)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePosition.x < transform.position.x)
                transform.eulerAngles = new Vector3(0, 0, 180);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
