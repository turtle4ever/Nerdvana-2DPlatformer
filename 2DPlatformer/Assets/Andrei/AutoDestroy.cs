using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyAfter = 5;

    private void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}
