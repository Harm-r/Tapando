using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class zoom : MonoBehaviour{
    // Start is called before the first frame update
    public float zoomFactor = 0.1f;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if (Input.touchCount == 2){
            Touch fingerOne = Input.GetTouch(0);
            Touch fingerTwo = Input.GetTouch(1);

            float prevDistance = (getPrevPos(fingerOne) - getPrevPos(fingerTwo)).magnitude;
            float distance = (fingerOne.position - fingerTwo.position).magnitude;
            float diff = distance - prevDistance;

            zoom(diff * zoomFactor);
        }
    }

    Vector2 getPrevPos(Touch touch){
        return touch.position - touch.deltaPosition;
    }

    void zoom(float zoom){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoom, zoomOutMin, zoomOutMax);
    }
}