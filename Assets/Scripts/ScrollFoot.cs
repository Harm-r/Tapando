using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollFoot : MonoBehaviour
{
    private Button button;
    private int stepSize = -1;
    private GameObject footModel;
    private List<string> stepNames = new List<string>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        // initialise variables
        footModel = GameObject.Find("FootModel");
        button = this.GetComponent<Button>();
        
        // check if this is next or previous button
        bool next = this.name.Contains("Next");
        if (next) stepSize = 1;
        
        // get step names
        stepNames = GetStepNames();
        button.onClick.AddListener(ScrollBetweenFeet);
    }
    
    void ScrollBetweenFeet(){
        // check which components will need altered visibility
        List<string> steps = GetCurrentSteps(stepNames, footModel);
        string currentStep = "";
        if (steps.Count > 0) currentStep = steps[steps.Count - 1];
        
        // if there are no tapes active and user wants the next tape, activate the first tape
        if (currentStep == "" && stepSize == 1) {
            footModel.transform.Find(stepNames[0]).gameObject.SetActive(true);
            return;
        }
        
        // if the user want to go from the first taping step to the initial foot, deactivate the first tape
        if (currentStep == "Tape_1.1" && stepSize == -1){
            footModel.transform.Find("Tape_1.1").gameObject.SetActive(false);
            return;
        }
        
        // get the next step according to the direction the user wants to step
        string nextStep = stepNames[GetIndexFromStep(currentStep) + stepSize];
        
        // activate the next step
        footModel.transform.Find(nextStep).gameObject.SetActive(true);
        
        // check if the current step should remain active or be deactivated
        if (isSameTape(currentStep, nextStep) || (!isSameTape(currentStep, nextStep) && stepSize == -1)){
            footModel.transform.Find(currentStep).gameObject.SetActive(false);
        }
    }
    
    // function that returns all tapes contained in the foot model, with the format "Tape_x.y"
    public List<string> GetStepNames(){
        List<string> steps = new List<string>();
        int children = footModel.transform.childCount;
        
        // add all children containing the word "Tape" in the name to the list
        for (int i = 0; i < children; i++){
            GameObject obj = footModel.transform.GetChild(i).gameObject;
            if (obj.name.Contains("Tape")) steps.Add(obj.name);
        }
        
        // sort the list before returning
        steps.Sort();
        return steps;
    }
    
    // function that returns all currently active pieces of tape
    public List<string> GetCurrentSteps(List<string> steps, GameObject foot){
        List<string> activeSteps = new List<string>();
        
        // add all active children also in stepNames to the list
        foreach (string name in steps){
            GameObject child = foot.transform.Find(name).gameObject;
            if (child.activeSelf) activeSteps.Add(name);
        }
        
        // sort the list before returning, such that the latest step is last in the list
        activeSteps.Sort();
        return activeSteps;
    }
    
    // function that returns the index of a specific taping step in the stepNames, or -1 if the taping step is not in the list
    int GetIndexFromStep(string stepName){
        for (int i = 0; i < stepNames.Count; i++){
            if (stepName == stepNames[i]) return i;
        }
        return -1;
    }
    
    // function that returns true if the stepA belongs to the same piece of tape as stepB
    bool isSameTape(string stepA, string stepB){
        int tapeA = Int16.Parse(stepA.Substring(5).Split('.')[0]);
        int tapeB = Int16.Parse(stepB.Substring(5).Split('.')[0]);
        return tapeA == tapeB;
    }
}
