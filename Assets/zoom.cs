using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class zoom : MonoBehaviour{
    // Start is called before the first frame update
    public float zoomFactor = 0.1f;
    public float minZoom = 1;
    public float maxZoom = 8;
    private Camera cam;
    public bool test = true;
    private float test_zoom;

    void Start(){
        cam = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.touchCount == 2 && !test){
            Touch fingerOne = Input.GetTouch(0);
            Touch fingerTwo = Input.GetTouch(1);

            float prevDistance = (getPrevPos(fingerOne) - getPrevPos(fingerTwo)).magnitude;
            float distance = (fingerOne.position - fingerTwo.position).magnitude;
            float diff = distance - prevDistance;

            perform_zoom(diff * zoomFactor);
        }
        // automatically zooms in and out to test limits on PC
        // TODO: remove case before final handin
        else if (test){
            test_zoom = zoomFactor;
            if (((int) Time.time) % 10 == 0) test_zoom = -test_zoom;
            perform_zoom(test_zoom);
            Debug.Log("Orthographic size: " + cam.orthographicSize);
        }
    }

    Vector2 getPrevPos(Touch touch){
        return touch.position - touch.deltaPosition;
    }

    void perform_zoom(float zoom_diff){
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - zoom_diff, minZoom, maxZoom);
    }
}
