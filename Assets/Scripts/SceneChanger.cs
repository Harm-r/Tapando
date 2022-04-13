using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void Homescreen()
    {
        SceneManager.LoadScene("Homescreen");
       
    }
    public void TempSecond()
    {
        SceneManager.LoadScene("TempSecond");
       
    }
    public void RotateUI()
    {
        SceneManager.LoadScene("ModelScene");
    }
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}