using UnityEngine;
using UnityEngine.UI;

public class CreditsPanelScript : MonoBehaviour
{
    public Button returnButton;
    public Button contactButton;
    public CanvasGroup creditsPanel;

    void Start()
    {
        returnButton.onClick.AddListener(OnClickReturn);
        contactButton.onClick.AddListener(OnClickGo);
    }

    void OnClickGo()
    {
        SoundScript.instance.PlayClickSfx();
        Application.OpenURL("https://www.instagram.com/yasrvie/");
    }

    void OnClickReturn()
    {
        SoundScript.instance.PlayClickSfx();
        PanelScript.instance.TogglePanelState(creditsPanel);
    }
}
