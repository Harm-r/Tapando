using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** SLIDER SCRIPT
*   Script that handles the drop-down text instructions.
*   To use, attach function to OnClick of the button you
*   want to have change the visibility of the instructions.
*/
public class SliderScript : MonoBehaviour
{
    public GameObject Instructions;

    // function that handles the drop do
    public void ShowHideInstructions() {
        // if there are instructions
        if (Instructions != null)
        {
            // if the animator exists, animate the scrolling up and down.
            Animator animator = Instructions.GetComponent<Animator>();
            if (animator != null)
            {
                bool Show = animator.GetBool("Show");
                animator.SetBool("Show", !Show);
            }
        }
    }
}
