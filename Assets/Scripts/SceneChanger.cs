using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** SCENE CHANGER SCRIPT
*   Script that switches the view to a different scene.
*   To use, attach the button object to the OnClick listeners.
*   Select the SceneChanger component and the RotateUI function.
*   In the field below, set the name of the scene you want to change to.
*/
public class SceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.60f;
    
    // function that is invoked when the button is clicked on. initiates scene transition
    public void ChangeSceneWithAnimation(string sceneName){
        StartCoroutine(RotateScene(sceneName));
    }

    // function that handles animations and scene transitions
    IEnumerator RotateScene(string sceneName){
        // use specific animation on scene transition to ModelScene
        if (sceneName == "ModelScene") {
            transition.SetTrigger("circleOut");
            yield return new WaitForSeconds(transitionTime);
        } 
        // otherwise use default animation
        else {
            transition.SetTrigger("RollInTrigger");
            yield return new WaitForSeconds(transitionTime-0.2f);
        }
        // load scene when animation has finished playing
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}