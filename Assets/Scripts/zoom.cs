using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* ZOOM SCRIPT
*  Used to detect pinch movements on a touch screen.
*  Zooms in and out on a 3D model in the 2D UI.
* 
*  To use, attach to any camera-object with orthographic projection pointing at 3D model.
*/

public class zoom : MonoBehaviour{
    public float zoomFactor = 0.1f;
    public float minZoom = 1;
    public float maxZoom = 8;
    private Camera cam;

    // Start is called before the first frame update
    void Start(){
        cam = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.touchCount >= 2){
            // get touch inputs
            Touch fingerOne = Input.GetTouch(0);
            Touch fingerTwo = Input.GetTouch(1);

            // get difference of distance between fingers
            float prevDistance = (getPrevPos(fingerOne) - getPrevPos(fingerTwo)).magnitude;
            float distance = (fingerOne.position - fingerTwo.position).magnitude;
            float diff = distance - prevDistance;

            perform_zoom(diff * zoomFactor);
        }
    }

    // function that returns the previous position of a specific touch
    public Vector2 getPrevPos(Touch touch){
        return touch.position - touch.deltaPosition;
    }

    // function that changes the orthographic size of the camera, zooming in and out as a result
    public void perform_zoom(float zoom_diff){
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - zoom_diff, minZoom, maxZoom);
    }

    // setter needed for unit testing
    public void setCamera(Camera camera)
    {
        this.cam = camera;
    }
}
