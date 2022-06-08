using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public Button tileButton;
    public GameObject symbolEnable;
    public Image symbolComponent;
    public CardData card;
    public bool state;
    public Action<TileScript> onClickHandler;

    void Awake()
    {        
        Hide();
    }

    private void OnClickTurn()
    {
        SoundScript.instance.PlayFlipSfx();
        onClickHandler(this);
    }

    public void Show() 
    {
        symbolEnable.SetActive(true);
        state = true;
    }

    public void Hide()
    {
        symbolEnable.SetActive(false);
        state = false;
    }

    public void AddListeners()
    {
        tileButton.onClick.AddListener(OnClickTurn);
    }

    public void RemoveListeners()
    {
        tileButton.onClick.RemoveListener(OnClickTurn);
    }

    public void ShowAndHide(float delayShow, float duration)
    {
        StartCoroutine(ChangeState(true, delayShow));
        StartCoroutine(ChangeState(false, delayShow + duration));
    }

    public void Clear()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject, 0.4f);
        }
    }

    public void SetData(CardData cardObj)
    {
        this.card = cardObj;
        this.symbolComponent.sprite = this.card.sprite;
    }

    IEnumerator ChangeState(bool stateNow, float time)
    {
        yield return new WaitForSeconds(time);
        if (stateNow) {
            Show();
        } else {
            Hide();
        }
    }

}
