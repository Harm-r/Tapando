using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScan : MonoBehaviour
{
    public void Scan()
    {
        SceneManager.LoadScene("Model");
    }
    
}
