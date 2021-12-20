using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitViewController : MonoBehaviour
{
    public void OnReturn()
    {
        ViewManager.instance.View_Return();
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("Master");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
