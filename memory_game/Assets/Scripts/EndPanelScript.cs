using System;
using UnityEngine;
using UnityEngine.UI;

public class EndPanelScript : MonoBehaviour
{
    public Button tryAgainButton;
    public Button menuButton;
    public Button nextButton;
    public TMPro.TextMeshProUGUI textField;
    public ScoreScript scoreField;
    public Action onRestartClickHandler;
    public Action onNextClickHandler;

    void Start()
    {
        tryAgainButton.onClick.AddListener(OnClickReturn);
        menuButton.onClick.AddListener(OnClickMenu);
        nextButton.onClick.AddListener(OnClickNext);
    }

    void OnClickNext()
    {
        SoundScript.instance.PlayClickSfx();
        onNextClickHandler();
    }

    void OnClickMenu()
    {
        SoundScript.instance.PlayClickSfx();
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.LevelMapScene);
    }

    void OnClickReturn()
    {
        SoundScript.instance.PlayClickSfx();
        onRestartClickHandler();
    }

    public void SetResult(int result, int attempts, bool hasNextLevel)
    {
        nextButton.gameObject.SetActive(hasNextLevel);
        if (result > 0)
        {
            this.textField.text = "Parabéns! Você conseguiu com terminar " + attempts.ToString() + " tentativas!";            
        } else
        {
            this.textField.text = "Você terminou com " + attempts.ToString() + " tentativas!";
            nextButton.gameObject.SetActive(false);
        }        
        scoreField.SetScore(result, true);
    }
}
