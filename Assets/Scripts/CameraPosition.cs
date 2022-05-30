using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPosition : MonoBehaviour
{
    public enum Angle {Left,Right,Front };
    public Angle CameraFocus;

    // Update is called once per frame

   public Vector3 GivePosition()
    {
       Vector3 currentScale = GameObject.Find("FootModel").GetComponent<Transform>().localScale;
       Vector3 rotationToReturn;

        //check the which angle must be given and return that vector
        switch (CameraFocus)
        {
            case Angle.Left:
                rotationToReturn = new Vector3(0, 90, 0);
                break;
            case Angle.Right:
                rotationToReturn = new Vector3(0, 270, 0);
                break;
            default:
                rotationToReturn = new Vector3(0, 0, 0);
                break;

        }
        //if the foot is currently inversed, rotate the y axis
        if (currentScale.x < 0)
        {
            return new Vector3(rotationToReturn.x, -rotationToReturn.y, rotationToReturn.z);
        }
        return rotationToReturn;
    }
}
