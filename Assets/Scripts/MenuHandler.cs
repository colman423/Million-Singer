using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}