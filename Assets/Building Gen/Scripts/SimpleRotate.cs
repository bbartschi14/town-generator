using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public float speed = .1f;
    
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, speed, 0f));
    }
}
