using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

/* ROTATION SCRIPT
* Detects single finger drags on a touch screen.
* Rotates a 3D model based on these single finger movements.
*
* To use, attach to any GameObject with a 3D model.
*/

public class rotation : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    private bool shouldRotate;
    private bool secondFrame;
    private bool horizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if exactly one finger is touching the screen
        if (Input.touchCount == 1)
        {
            // Get touch input
            Touch touch = Input.GetTouch(0);
           //check what touch phase the touch is in
            switch (touch.phase)
            {
                //if this is the first frame of the touch we check whether the touch is on the model and let the next iteration of the function know it is the second frame
                case TouchPhase.Began:
                    secondFrame = true;
                    if (TouchIsOnModel())
                    {
                        shouldRotate = true;
                    }
                    else
                    {
                        shouldRotate = false;
                    }
                    break;
               
                case TouchPhase.Moved:
                    Vector2 diff = touch.deltaPosition;
                    //if it is the first frame of movement(secondFram = true) we check which axis the object needs to turn on
                    if (secondFrame == true)
                    {
                        secondFrame = false;
                        if (Math.Abs(diff.x) > Math.Abs(diff.y))
                            {
                                horizontal = true;
                            } else
                            {
                                horizontal = false;
                            }
                    }
                    // rotate the object on the axis found
                    Vector2 rotateFactor = new Vector2(0,0);
                    if (shouldRotate)
                    {
                        if (horizontal)
                        {
                            rotateFactor.Set(diff.x, 0);
                            rotateModel(rotateFactor * rotSpeed,horizontal);
                        }
                        else
                        {
                            rotateFactor.Set(0, diff.y);
                            rotateModel(rotateFactor * rotSpeed,horizontal);
                        }
                    }
                   
                    break;
                case TouchPhase.Ended:
                    break;
            }


        }
    }
    
    void perform_zoom(float v)
    {
        throw new NotImplementedException();
    }

    // Performs a rotation on a 3D model using the provided factors
    public void rotateModel(Vector2 rotateFactor, bool horizontal) {
        if (horizontal)
        {
            transform.Rotate(rotateFactor.y, -rotateFactor.x, 0, Space.Self);
        } else
        {
            transform.Rotate(rotateFactor.y, -rotateFactor.x, 0, Space.World);
        }
       
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
