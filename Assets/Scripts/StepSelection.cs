using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** STEP SELECTION SCRIPT
*   Script that handles the activation of the buttons that allow for specific step
*   selection in the bottom of the ModelScene.
*   To use, attach to the "Content" element of a ScrollView game object.
*   Assumes the foot model contains the steps in the usual "Tape_x.y" format.
*/
public class StepSelection : MonoBehaviour
{
    private ScrollFoot scrollFoot;
    private GameObject footModel;
    private List<string> stepNames;
    private ScrollRect scrollRect;
    private string prevStep = "Tape_0";
    
    // Start is called before the first frame update
    void Start()
    {
        // get the foot model and script
        footModel = GameObject.Find("FootModel");
        scrollFoot = FindObjectOfType<ScrollFoot>();
	    ResetCamera resetCamera = FindObjectOfType<ResetCamera>();
	    Camera cam = GameObject.Find("3dObjectCamera").GetComponent<Camera>();
        // add onClick listener to each button. Assumes exactly enough empty buttons have been created
        foreach (Transform child in transform){
            Button btn = child.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(delegate{
		        scrollFoot.SelectStep(child.gameObject.name, footModel); 
		        resetCamera.CameraReset(cam, footModel);
	        });
        }

        // get step names for update function
        stepNames = scrollFoot.GetStepNames(footModel);

        // find ScrollRect component of carousel
        scrollRect = GameObject.Find("Carousel").GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
	// find out the current step
	List<string> currentSteps = scrollFoot.GetCurrentSteps(stepNames, footModel);
        if (currentSteps.Count == 0) currentSteps.Add("Tape_0");
        string currentStep = currentSteps[currentSteps.Count - 1];
	
	// button object that needs to be in view
	RectTransform stepButton = new RectTransform();

	// make button that is of current step slightly larger
        foreach (Transform child in transform){
	    if (child.name == currentStep){
		child.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		stepButton = child.gameObject.GetComponent<RectTransform>();
            }
	    else{
		child.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            }
        } 

	if (currentStep != prevStep){
            // set button object of current step in view
	    float scroll = stepButton.anchoredPosition.x/scrollRect.content.rect.width;
	    if (currentStep == "Tape_0") scrollRect.horizontalScrollbar.value = 0;
	    if (currentStep == stepNames[stepNames.Count - 1]) scrollRect.horizontalScrollbar.value = 1;
	    scrollRect.horizontalScrollbar.value = scroll;
	    prevStep = currentStep;
        }
    }
}
