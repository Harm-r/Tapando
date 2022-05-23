using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** SCROLL FOOT VISIBILITY SCRIPT
*   Script that handles the visibility of the buttons that scroll
*   between different steps of taping instructions.
*/
public class ScrollFootVisibility : MonoBehaviour
{
    private GameObject footModel;
    private List<string> stepNames = new List<string>();
    private ScrollFoot scrollFoot;
    
    // Start is called before the first frame update
    void Start(){
        // initialise variables for update function
        scrollFoot = FindObjectOfType<ScrollFoot>();
        footModel = GameObject.Find("FootModel");
        stepNames = scrollFoot.GetStepNames();
    }

    // Update is called once per frame
    void Update(){
        // check which steps are currently active
        List<string> currentSteps = scrollFoot.GetCurrentSteps(stepNames, footModel);
        
        // if no steps are active, remove access to previous step button
        if (currentSteps.Count == 0){
            transform.Find("Previous").gameObject.SetActive(false);
        }
        else{
            transform.Find("Previous").gameObject.SetActive(true);
        }
        
        // if final step is active, remove access to next step button
        if (currentSteps.Count > 0 && currentSteps[currentSteps.Count - 1] == stepNames[stepNames.Count - 1]){
            transform.Find("Next").gameObject.SetActive(false);
        }
        else{
            transform.Find("Next").gameObject.SetActive(true);
        }
    }
}
