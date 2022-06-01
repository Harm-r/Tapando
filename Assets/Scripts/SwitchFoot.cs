using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/** SWITCH FOOT SCRIPT
*   Script that adds the onClick listener to the button that switches between
*   the left and right foot.
*   To use, add to object with button component to be used for this purpose.
*/
public class SwitchFoot : MonoBehaviour
{
    public Button button;
    private GameObject footModel;
    public Text textField;
    
    // Start is called before the first frame update
    void Start()
    {
    	footModel = GameObject.Find("FootModel");
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SwitchBetweenFeet);
        textField = button.GetComponentInChildren<Text>();
    }

    // function that switches between the left and right foot, by inverting the scale of the x-axis of the model    
    void SwitchBetweenFeet(){
    	Transform transform = footModel.GetComponent<Transform>();
        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);

        // Change the letter in the button
        if(currentScale.x > 0f){
            textField.text = "R";
        } else{
            textField.text = "L";
        }
    }
}
