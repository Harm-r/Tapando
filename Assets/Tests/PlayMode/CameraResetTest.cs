using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraResetTest
{
    private GameObject testObject;
    private Camera testCam;
    private Transform testTransform;
    private ResetCamera resetScript;
    
    [SetUp]
    public void Setup(){
        testObject = new GameObject();
        testCam = testObject.AddComponent<Camera>();
        testTransform = testObject.GetComponent<Transform>();
        resetScript = testObject.AddComponent<ResetCamera>();
    }
    
    [Test]
    public void TestResetFunc(){
        var rnd = new System.Random();
        testTransform.Rotate(rnd.Next(-100,100), rnd.Next(-100,100), 0, Space.World);
        testCam.orthographicSize = rnd.Next(1,8);
        resetScript.CameraReset(testCam, testTransform);
        Assert.AreEqual(testCam.orthographicSize, 5);
        Assert.AreEqual(testTransform.rotation, Quaternion.identity);
    }
}
