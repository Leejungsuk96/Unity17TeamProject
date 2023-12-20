using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void OnSaveButtonClick()
    {
        SceneManager.LoadScene("hyenkuen");
    }

    public void OnLoadButtonClick()
    {
        SceneManager.LoadScene("hyenkuen");
    }

    public void OnGameStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
