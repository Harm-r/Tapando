using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SwitchFoot : MonoBehaviour
{
    public Button button;
    private GameObject footModel;
    private string meshName;
    
    // Start is called before the first frame update
    void Start()
    {
    	footModel = GameObject.Find("FootModel");
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SwitchBetweenFeet);
    }
    
    void SwitchBetweenFeet(){
    	Transform transform = footModel.GetComponent<Transform>();
        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
