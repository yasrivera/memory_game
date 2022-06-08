using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonScript : MonoBehaviour
{
    [HideInInspector] public int levelButtonId;
    public Button levelButton;
    public ScoreScript levelScore;
    public TMPro.TextMeshProUGUI textField;
    public Action<int> onSelectHandler;

    void Start()
    {
        levelButton.onClick.AddListener(OnClickSelect);
    }

    private void OnClickSelect()
    {
        SoundScript.instance.PlayClickSfx();
        onSelectHandler(this.levelButtonId);
    }

    public void SetLevelNumber(int levelId)
    {
        this.levelButtonId = levelId;
        this.textField.text = (levelId + 1).ToString();
    }

    public void SetVisualScore(int result)
    {
        levelScore.SetScore(result, false);
    }

    public void BlockInteractions()
    {
        levelButton.onClick.RemoveListener(OnClickSelect);
        levelButton.interactable = false;
        levelScore.gameObject.SetActive(false);
    }
}
