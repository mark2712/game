using UnityEngine;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
    public Button playMainButton;
    public Button playLevel1Button;

    void Start()
    {
        // открыть UI главного меню

        playMainButton.onClick.AddListener(() => OnPlayClicked(GameScenes.Main));
        playLevel1Button.onClick.AddListener(() => OnPlayClicked(GameScenes.Level1));
    }

    void OnPlayClicked(string sceneName)
    {
        // Debug.Log(sceneName);
        ScenesManager.Instance.LoadScene(sceneName);
    }
}