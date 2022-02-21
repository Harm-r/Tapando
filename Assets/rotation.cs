using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    rotX = touch.position.X;
                    rotY = touch.position.Y;
                    break;
                // Rotate 3D model based on finger movements
                case TouchPhase.Moved:
                    curX = touch.position.X;
                    curY = touch.position.Y;
                    transform.Rotate(Math.sign(curY - rotY) * rotSpeed, Math.sign(curX - rotX) * rotSpeed, 0, Space.World);
                    rotX = curX;
                    rotY = curY;
                    break;
            }
        }
    }
}
