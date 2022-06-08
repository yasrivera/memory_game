using UnityEngine;
using UnityEngine.UI;

public class LevelMapScreen : MonoBehaviour
{
    public static LevelMapScreen instance;
    public Button settingsButton;
    public Button homeButton;
    public CanvasGroup settingsPanel;

    void Start()
    {
        settingsButton.onClick.AddListener(OnClickSettings);        
        homeButton.onClick.AddListener(onClickHome);
    }     

    private void onClickHome()
    {
        SoundScript.instance.PlayClickSfx();
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.SplashScene);
    }

    private void OnClickSettings()
    {
        SoundScript.instance.PlayClickSfx();
        PanelScript.instance.TogglePanelState(settingsPanel);
    }    
}
