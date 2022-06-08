using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    public Image logo;
    public Button playButton;
    public Button settingsButton;
    public Button creditsButton;
    public CanvasGroup settingsPanel;
    public CanvasGroup creditsPanel;

    void Start()
    {
        AnimateLogo();
        playButton.onClick.AddListener(onClickPlay);
        AnimatePlayButton();
        settingsButton.onClick.AddListener(OnClickSettings);
        creditsButton.onClick.AddListener(OnClickCredits);
    }

    void AnimatePlayButton()
    {
        playButton.transform.localScale = Vector3.zero;
        playButton.transform.DOScale(Vector3.one, 1f).SetEase(Ease.InBounce).SetDelay(0.5f);
    }

    void AnimateLogo()
    {
        logo.transform.localScale = Vector3.zero;
        logo.transform.DOScale(Vector3.one, 2f).SetEase(Ease.OutBounce).SetDelay(0);
    }

    private void onClickPlay()
    {
        SoundScript.instance.PlayClickSfx();
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.LevelMapScene);
    }
    private void OnClickSettings()
    {
        SoundScript.instance.PlayClickSfx();
        PanelScript.instance.TogglePanelState(settingsPanel);
    }
    private void OnClickCredits()
    {
        SoundScript.instance.PlayClickSfx();
        PanelScript.instance.TogglePanelState(creditsPanel);
    }
}
