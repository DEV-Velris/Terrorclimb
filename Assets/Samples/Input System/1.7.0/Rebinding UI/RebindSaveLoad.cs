using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;

    public void Awake()
    {
        SceneManager.sceneLoaded += (scene, mode) => HandleSceneEnter();
        SceneManager.sceneUnloaded += (scene) => HandleSceneExit();
    }

    private void HandleSceneEnter()
    {
        var rebinds = PlayerPrefs.GetString("keybindings");
        if (!string.IsNullOrEmpty(rebinds))
        {
            actions.LoadBindingOverridesFromJson(rebinds);
        }
    }
    
    private void HandleSceneExit()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("keybindings", rebinds);
    }
}
