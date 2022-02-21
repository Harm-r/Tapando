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
        // Get the touch of a finger
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            switch(touch.phase){
                // Get starting coordinates of drag if touch just started
                case TouchPhase.Began:
                    rotX = touch.position.x;
                    rotY = touch.position.y;
                    break;
                // Rotate 3D model based on finger movements
                case TouchPhase.Moved:
                    float curX = touch.position.x;
                    float curY = touch.position.y;
                    transform.Rotate(Math.Sign(curY - rotY) * rotSpeed, Math.Sign(curX - rotX) * rotSpeed, 0, Space.World);
                    rotX = curX;
                    rotY = curY;
                    break;
            }
        }
    }
}
