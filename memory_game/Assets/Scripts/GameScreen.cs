using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    public Button settingsButton;
    public Button returnButton;
    public CanvasGroup settingsPanel;

    void Start()
    {
        settingsButton.onClick.AddListener(OnClickSettings);
        returnButton.onClick.AddListener(OnClickReturn);
    }

    private void OnClickReturn()
    {
        SoundScript.instance.PlayClickSfx();
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.LevelMapScene);
    }

    private void OnClickSettings()
    {
        SoundScript.instance.PlayClickSfx();
        PanelScript.instance.TogglePanelState(settingsPanel);
    }
}
