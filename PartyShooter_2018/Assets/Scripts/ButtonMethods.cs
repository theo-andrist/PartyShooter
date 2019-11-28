using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void DisableObject(GameObject o)
    {
        o.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
