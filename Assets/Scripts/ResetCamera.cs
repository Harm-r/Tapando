using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** RESET CAMERA FUNCTION
 *  Script that finds the model and camera in a model scene, and resets them to their default position.
 *  To use, add script to button component of GameObject.
 */
public class ResetCamera : MonoBehaviour
{
    public Button button;
    public Camera cam;
    public Transform foot;
    
    // Start is called before the first frame update
    public void Start()
    {
        // get components needed for script to work
        Button btn = button.GetComponent<Button>();
        cam = GameObject.Find("3dObjectCamera").GetComponent<Camera>();
        foot = GameObject.Find("FootModel").GetComponent<Transform>();
        
        // Add listener
        // Done with lambda expression for easier testing
        btn.onClick.AddListener(() => CameraReset(cam, foot));
    }
    
    // function that is called to update the camera
    public void CameraReset(Camera cam, Transform foot){
    	cam.orthographicSize = 5;
    	foot.rotation = Quaternion.identity;
    }
}
