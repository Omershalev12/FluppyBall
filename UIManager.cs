using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string firstSceneName;
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(firstSceneName);
    }

    public void Store()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
