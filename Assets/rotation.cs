using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* ROTATION SCRIPT
* Detects single finger drags on a touch screen.
* Rotates a 3D model based on these single finger movements.
*
* To use, attach to any GameObject with a 3D model.
*/

public class rotation : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if exactly one finger is touching the screen
        if (Input.touchCount == 1){
            // Get touch input
            Touch touch = Input.GetTouch(0);
            
            // Get difference of finger position
            Vector2 diff = touch.deltaPosition;
            Vector2 rotateFactor = new Vector2(diff.x, diff.y);
            
            rotateModel(rotateFactor * rotSpeed);
        }
    }
    
    // Performs a rotation on a 3D model using the provided factors
    void rotateModel(Vector2 rotateFactor){
        transform.Rotate(rotateFactor.y, rotateFactor.x, 0, Space.World);
    }
}
