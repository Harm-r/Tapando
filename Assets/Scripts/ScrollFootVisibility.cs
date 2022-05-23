using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFootVisibility : MonoBehaviour
{
    private GameObject footModel;
    private List<string> stepNames = new List<string>();
    private ScrollFoot scrollFoot;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollFoot = transform.GetChild(0).gameObject.GetComponent<ScrollFoot>();
        Debug.Log(transform.GetChild(0).gameObject);
        footModel = GameObject.Find("FootModel");
        stepNames = scrollFoot.GetStepNames();
    }

    // Update is called once per frame
    void Update()
    {
        List<string> currentSteps = scrollFoot.GetCurrentSteps(stepNames, footModel);
        
        if (currentSteps.Count == 0){
            transform.Find("Previous").gameObject.SetActive(false);
        }
        else{
            transform.Find("Previous").gameObject.SetActive(true);
        }
        
        if (currentSteps.Count > 0 && currentSteps[currentSteps.Count - 1] == stepNames[stepNames.Count - 1]){
            transform.Find("Next").gameObject.SetActive(false);
        }
        else{
            transform.Find("Next").gameObject.SetActive(true);
        }
    }
}
