using UnityEngine;
using DG.Tweening;

public class StarScript : MonoBehaviour
{
    public GameObject starOn;
    public GameObject starOff;

    public void setOn()
    {
        starOn.SetActive(true);
        starOff.SetActive(false);
    }

    public void AnimateStar(float delay)
    {
        starOn.transform.localScale = Vector3.zero;
        starOn.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(delay);
        starOff.transform.localScale = Vector3.zero;
        starOff.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(delay);
    }
}
