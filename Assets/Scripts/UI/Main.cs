using UnityEngine;

public class Main : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Test Movements");
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
