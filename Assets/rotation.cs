using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotSpeed = 1000;
    private float startingX;
    private float startingY;
    
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
                    startingX = touch.position.x;
                    startingY = touch.position.y;
                    break;
                // Calculate relative coordinates and rotate 3D object based on that
                case TouchPhase.Moved:
                    float relativeX = (startingX - touch.position.x) * rotSpeed * Time.deltaTime;
                    float relativeY = (startingY - touch.position.y) * rotSpeed * Time.deltaTime;
                    transform.Rotate(relativeX, relativeY, 0, Space.World);
                    break;
            }
        }
    }
}
