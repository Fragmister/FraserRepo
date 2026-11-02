using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public string SceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}

