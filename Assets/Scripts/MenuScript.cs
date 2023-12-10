using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnPressStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnPressOptions()
    {
        //open options canvas
    }
    public void OnPressExit()
    {
        Application.Quit();
    }
    public void OnPressCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
