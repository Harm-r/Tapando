using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RotationEditTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void RotationTestSimplePasses()
	{
        var foot = new GameObject();
        foot.AddComponent<rotation>();
        
        rotation Rotation = new rotation();
        Vector3 zeroVector = new Vector3(0, 0, 0);
        Vector2 rotateFactor = new Vector2(0, 0);
        //Vector3 newVector = rotation.rotateModel(rotateFactor);

        //Assert.AreEqual(zeroVector, newVector);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator RotationTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
