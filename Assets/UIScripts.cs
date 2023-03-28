using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScripts : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }
    public void LoadLevel(int level)
    {
        Debug.Log("load level");
        SceneManager.LoadScene(level);
    }
}
