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
        return Vector3.left;
    }
}
