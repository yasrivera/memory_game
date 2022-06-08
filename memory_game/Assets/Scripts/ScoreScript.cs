using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public List<StarScript> star;

    public void SetScore(int result, bool isAnimated)
    {
        for (var i = 0; i < result; i++)
        {
            star[i].setOn();            
        }
        if (isAnimated)
        {
            AnimateStars();
        }
    }

    private void AnimateStars()
    {
        for (var i = 0; i < star.Count; i++) {
            star[i].AnimateStar(i * 0.5f);
        }
    }
}
