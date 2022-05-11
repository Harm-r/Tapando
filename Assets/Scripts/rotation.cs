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
    //public Collider collider;
    
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
    
   void perform_zoom(float v)
    {
        throw new NotImplementedException();
    }

    // Performs a rotation on a 3D model using the provided factors
    public void rotateModel(Vector2 rotateFactor) {
        transform.Rotate(rotateFactor.y, -rotateFactor.x, 0, Space.World);
    }

    //bool IsTouchOverThisObject(Touch touch) {
    //     Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
    //     RaycastHit hit;

    //     // you may need to adjust the max distance paramter here based on your
    //     // scene size/scale.
    //     return collider.Raycast(ray, out hit, 1000.0f); 
    //}
}
