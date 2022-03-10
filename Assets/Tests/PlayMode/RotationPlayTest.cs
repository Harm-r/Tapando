using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class RotationPlayTest
{
    private GameObject testObject;
    private zoom rotateScript;


    [SetUp]
    public void Setup()
    {
        testObject = Object.Instantiate(new GameObject());
        rotateScript = testObject.AddComponent<rotation>();
    }

    [Test]
    public void InitialRotationZero()
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

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator RotationPlayTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
