using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepSelection : MonoBehaviour
{
    private ScrollFoot scrollFoot;
    private GameObject footModel;
    
    // Start is called before the first frame update
    void Start()
    {
        footModel = GameObject.Find("FootModel");
        scrollFoot = FindObjectOfType<ScrollFoot>();
        foreach (Transform child in transform){
            Button btn = child.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(delegate{scrollFoot.SelectStep(child.gameObject.name, footModel);});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
