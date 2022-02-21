using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rotation : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    private float rotX;
    private float rotY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime);
        transform.Rotate(Vector2.up * Time.deltaTime);
        transform.Rotate(Vector3.up *2* Time.deltaTime);
    }
}