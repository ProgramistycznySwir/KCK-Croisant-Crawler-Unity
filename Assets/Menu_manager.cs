using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_manager : MonoBehaviour
{

    public int index;
    public void LoadGame()
    {
        SceneManager.LoadScene(index);
    }
}
