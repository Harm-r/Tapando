using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/** RESET CAMERA FUNCTION
 *  Script that finds the model and camera in a model scene, and resets them to their default position.
 *  To use, add script to button component of GameObject.
 */
public class ResetCamera : MonoBehaviour
{
    public Button button;
    private Camera cam;
    private GameObject foot;
    
    // Start is called before the first frame update
    public void Start()
    {
        // get components needed for script to work
        Button btn = button.GetComponent<Button>();
        cam = GameObject.Find("3dObjectCamera").GetComponent<Camera>();
        foot = GameObject.Find("FootModel");
       
        // Done with lambda expression for easier testing
        btn.onClick.AddListener(() => CameraReset(cam, foot));
    }
    
    public void CameraReset(Camera cam, GameObject foot){
        //Find the scrollfoot component to use its functions and get the transform component of the foot
        ScrollFoot m_scrollfoot = GameObject.FindObjectOfType(typeof(ScrollFoot)) as ScrollFoot;
        Transform footTransform = foot.GetComponent<Transform>();
        cam.orthographicSize = 8;
        string currentStep = "";

        //get all the steps currently in view, if none currentstep is the empty foot
        List<string> stepsTaken = m_scrollfoot.GetCurrentSteps(m_scrollfoot.GetStepNames(foot), foot);
        if (stepsTaken.Count != 0)
        {
              currentStep = stepsTaken.Last();
        }

        else

        {
              currentStep = "Foot";
        }

        //Rotate the foot to the position found on the current tape step
       
        Vector3 transformVector = foot.transform.Find(currentStep).gameObject.GetComponent<CameraPosition>().GivePosition();
        footTransform.rotation = Quaternion.Euler(transformVector);
        
    }
}
