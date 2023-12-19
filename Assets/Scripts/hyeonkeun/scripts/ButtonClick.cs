using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void OnSaveButtonClick()
    {
        SceneManager.LoadScene("hyenkuen");
    }

    public void OnLoadButtonClick()
    {
        SceneManager.LoadScene("hyenkuen");
    }
}
