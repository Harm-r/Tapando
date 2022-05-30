using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

/* ROTATION SCRIPT
*  Detects single finger drags on a touch screen.
*  Rotates a 3D model based on these single finger movements.
*
*  To use, attach to any GameObject with a 3D model.
*/

public class rotation : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    private bool shouldRotate;

    // Update is called once per frame
    void Update()
    {
        // check if exactly one finger is touching the screen
        if (Input.touchCount == 1) {
            // get touch input
            Touch touch = Input.GetTouch(0);

            // check if the touch starts on a UI element
            if (touch.phase == TouchPhase.Began)
            {
                if (TouchIsOnModel()) {
                    shouldRotate = true;
                } 
                else {
                    shouldRotate = false;
                }
            }
            
            Vector2 rotateFactor = new Vector2(0, 0);

            // get difference of finger position
            Vector2 diff = touch.deltaPosition;
            rotateFactor = new Vector2(diff.x, diff.y);

            // rotate model if right conditions are met
            if (shouldRotate) {
                rotateModel(rotateFactor * rotSpeed);
            }
            
        }
    }

    // Performs a rotation on a 3D model using the provided factors
    public void rotateModel(Vector2 rotateFactor) {
        transform.Rotate(rotateFactor.y, -rotateFactor.x, 0, Space.World);
    }

    // Checks if the first element element hit with a raycast is the model, so no ui element 
    public static bool TouchIsOnModel()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = Input.mousePosition;

        // make a list of all elements that are hit
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0)
        {
            if (results[0].gameObject.name == "3dobject")
            {
                return true;
            }
        }
        return false;
    }

}
