using UnityEngine;

public class Options : MonoBehaviour
{

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main menu");
    }
    
}
