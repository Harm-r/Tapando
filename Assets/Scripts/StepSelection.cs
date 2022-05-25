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
    
    // Start is called before the first frame update
    void Start()
    {
        // get the foot model and script
        footModel = GameObject.Find("FootModel");
        scrollFoot = FindObjectOfType<ScrollFoot>();
        // add onClick listener to each button. Assumes exactly enough empty buttons have been created
        foreach (Transform child in transform){
            Button btn = child.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(delegate{scrollFoot.SelectStep(child.gameObject.name, footModel);});
        }
    }
}
