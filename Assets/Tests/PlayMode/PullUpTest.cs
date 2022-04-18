using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PullUpTest
{
    private RectTransform canvas;
    private RectTransform panel; 

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Homescreen");
        this.canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        this.panel = GameObject.Find("PullUpPanel").GetComponent<RectTransform>();

    }
    
    [Test]
    public void LerpBottom()
    {
        // initial rotation of object should be the same as zero vector,
        // eulerAngles: transforms quaternion to vector3

        //Assert.AreEqual(zeroVector, testObject.transform.rotation.eulerAngles);
    }
    /*
    [Test]
    public void LerpTop()
    {
        Vector3 zeroVector = new Vector3(0, 0, 0);

        // initial rotation of object should be the same as zero vector,
        // eulerAngles: transforms quaternion to vector3
        Assert.AreEqual(zeroVector, testObject.transform.rotation.eulerAngles);
    }

    [Test]
    public void RotationAfterRotatingObjectIsNotTheSame()
    {
        // create initial vector
        Vector3 initialRotation = testObject.transform.rotation.eulerAngles;

        // rotate the test object randomly
        Vector2 rotateFactor = new Vector2(Random.Range(0, 0.5f), Random.Range(0, 0.5f));
        rotateScript.rotateModel(rotateFactor);

        Assert.AreNotEqual(initialRotation, testObject.transform.rotation.eulerAngles);
    }
    */
}
