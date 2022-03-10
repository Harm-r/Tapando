using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ZoomTest
{
    private GameObject testObject;
    private Camera testCamera;
    private zoom zoomScript;

    [SetUp]
    public void Setup()
    {
        testObject = Object.Instantiate(new GameObject());
        testObject.AddComponent<Camera>();
        testCamera = testObject.GetComponent<Camera>();
        zoomScript = testObject.AddComponent<zoom>();
    }

    [Test]
    public void CameraZoomGetsBiggerWhenZoomedIn()
    {
        float initialZoom = testCamera.orthographicSize;
        zoomScript.perform_zoom(Random.Range(0, 0.5f));

        Assert.GreaterOrEqual(testCamera.orthographicSize, initialZoom);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ZoomTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
