using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelAnimation : MonoBehaviour
{
    public Image Background;
    public Transform Popup;
    public Image Button;

    private void OnShow()
    {
        Popup.transform.DOScale(0f, 0.0f);
        Button.transform.DOScale(0f, 0.0f);
        Background.color = new Color(Background.color.r, Background.color.g, Background.color.b, 0f);
        SetAllGameObjectActive(false);
    }

    private void SetAllGameObjectActive(bool state)
    {
        for (var index = 0; index < this.transform.childCount; index++)
        {
            var child = this.transform.GetChild(index);

            if (child.gameObject != Background.gameObject &&
                child.gameObject != Popup.gameObject &&
                child.gameObject != Button.gameObject
                )
            { 
                child.gameObject.SetActive(state);
            }
        }
    }

    public void Show() 
    {
        OnShow();

        Background.DOFade(.5f, 0.3f);
        Popup.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).SetDelay(0f);
        Button.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).SetDelay(0.3f).OnComplete(OnShowed);

    }

    private void OnShowed()
    {
        SetAllGameObjectActive(true);
    }

    public void Hide() 
    {
        Background.DOFade(0f, 0.3f);
        Popup.transform.DOScale(0f, 0.1f).SetEase(Ease.Linear);
    }
}