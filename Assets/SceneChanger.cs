using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime =0.60f;
    
    public void RotateUI(string sceneName)
    {
        StartCoroutine(RotateScene(sceneName));
    }
    IEnumerator RotateScene(string  sceneName)
    {
        if (sceneName == "ModelScene")
        {
            transition.SetTrigger("circleOut");
            yield return new WaitForSeconds(transitionTime);
        } else
        {
            transition.SetTrigger("RollInTrigger");
            yield return new WaitForSeconds(transitionTime-0.2f);
        }
        SceneManager.LoadScene(sceneName);
       


    }
}