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
        footModel = GameObject.Find("FootModel");
        button = this.GetComponent<Button>();
        bool next = this.name.Contains("Next");
        if (next) stepSize = 1;
        stepNames = GetStepNames();
        Debug.Log(stepNames.Count);
        button.onClick.AddListener(ScrollBetweenFeet);
        Debug.Log(this.gameObject);
    }
    
    void ScrollBetweenFeet(){
        // check which components will need altered visibility
        List<string> steps = GetCurrentSteps(stepNames, footModel);
        string currentStep = "";
        if (steps.Count > 0) currentStep = steps[steps.Count - 1];
        
        if (currentStep == "" && stepSize == 1) {
            footModel.transform.Find(stepNames[0]).gameObject.SetActive(true);
            return;
        }
        
        string nextStep = stepNames[GetIndexFromStep(currentStep) + stepSize];
        
        footModel.transform.Find(nextStep).gameObject.SetActive(true);
        
        if (isSameTape(currentStep, nextStep) || (!isSameTape(currentStep, nextStep) && stepSize == -1)){
            footModel.transform.Find(currentStep).gameObject.SetActive(false);
        }
    }
    
    public List<string> GetStepNames(){
        List<string> steps = new List<string>();
        int children = footModel.transform.childCount;
        for (int i = 0; i < children; i++){
            GameObject obj = footModel.transform.GetChild(i).gameObject;
            if (obj.name.Contains("Tape")) steps.Add(obj.name);
        }
        steps.Sort();
        return steps;
    }
    
    public List<string> GetCurrentSteps(List<string> steps, GameObject foot){
        List<string> activeSteps = new List<string>();
        foreach (string name in steps){
            GameObject child = foot.transform.Find(name).gameObject;
            if (child.activeSelf) activeSteps.Add(name);
        }
        activeSteps.Sort();
        return activeSteps;
    }
    
    int GetIndexFromStep(string stepName){
        for (int i = 0; i < stepNames.Count; i++){
            if (stepName == stepNames[i]) return i;
        }
        return -1;
    }
    
    bool isSameTape(string stepA, string stepB){
        int tapeA = Int16.Parse(stepA.Substring(5).Split('.')[0]);
        int tapeB = Int16.Parse(stepB.Substring(5).Split('.')[0]);
        return tapeA == tapeB;
    }
}
