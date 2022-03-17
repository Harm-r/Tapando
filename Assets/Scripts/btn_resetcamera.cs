using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_resetcamera : MonoBehaviour
{
    public Button button;
    public Camera cam;
    public Transform foot;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        cam = GameObject.Find("3dObjectCamera").GetComponent<Camera>();
        foot = GameObject.Find("Foot_Short").GetComponent<Transform>();
        btn.onClick.AddListener(ResetCamera);
    }
    
    void ResetCamera(){
    	cam.orthographicSize = 5;
    	foot.rotation = Quaternion.identity;
    }
}
