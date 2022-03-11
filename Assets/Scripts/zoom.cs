using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* ZOOM SCRIPT
* Used to detect pinch movements on a touch screen.
* Zooms in and out on a 3D model in the 2D UI.
* 
* To use, attach to any camera-object with orthographic projection pointing at 3D model.
*/

public class zoom : MonoBehaviour{
    public float zoomFactor = 0.1f;
    public float minZoom = 1;
    public float maxZoom = 8;
    private Camera cam;
    
    // variables used for testing automatic zooming
    // TODO: remove below before final handin
    public bool test = false;
    private float test_zoom;
    // TODO: remove above before final handin

    // Start is called before the first frame update
    void Start(){
        cam = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.touchCount == 2 && !test){
            // get touch inputs
            Touch fingerOne = Input.GetTouch(0);
            Touch fingerTwo = Input.GetTouch(1);
            Debug.Log("finger one: " + fingerOne + " - finger two: " + fingerTwo);

            // get difference of distance between fingers
            float prevDistance = (getPrevPos(fingerOne) - getPrevPos(fingerTwo)).magnitude;
            float distance = (fingerOne.position - fingerTwo.position).magnitude;
            float diff = distance - prevDistance;

            perform_zoom(diff * zoomFactor);
        }
        // automatically zooms in and out to test limits on PC
        // TODO: remove below before final handin
        //else if (test){
        //    test_zoom = zoomFactor;
        //    if (((int) Time.time) % 10 == 0) test_zoom = -test_zoom;
        //    perform_zoom(test_zoom);
        //    Debug.Log("Orthographic size: " + cam.orthographicSize);
        //}
        // TODO: remove above before final handin
    }

    public Vector2 getPrevPos(Touch touch){
        return touch.position - touch.deltaPosition;
    }

    public void perform_zoom(float zoom_diff){
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - zoom_diff, minZoom, maxZoom);
    }

    // needed for the test
    public void setCamera(Camera camera)
    {
        this.cam = camera;
    }
}
