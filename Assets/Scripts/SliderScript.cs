using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    public GameObject Instructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideInstructionsBig() {
        if (Instructions != null)
        {
            Animator animator = Instructions.GetComponent<Animator>();
            animator.SetBool("BigOn", true);
            if (animator != null)
            {
                bool Show = animator.GetBool("Show");
                animator.SetBool("Show", !Show);
            }
        }
    }

    public void ShowHideInstructionsSmall() {
        if (Instructions != null)
        {
            Animator animator = Instructions.GetComponent<Animator>();
            animator.SetBool("BigOn", false);
            if (animator != null)
            {
                bool Show = animator.GetBool("ShowSmall");
                animator.SetBool("ShowSmall", !Show);
            }
        }
    }


}
