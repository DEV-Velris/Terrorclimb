using UnityEngine;

public class Main : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test Movements");
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
