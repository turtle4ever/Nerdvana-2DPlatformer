using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponMouseFollow : MonoBehaviour
{
    public float maxTurnSpeed = 360;
    public float smoothTime = 0.3f;
    public bool instant = false;
    float angle;
    float currentVelocity;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

        if (instant)
        {
            angle = targetAngle;
        }
        else
        {
            angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocity, smoothTime, maxTurnSpeed);
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
