using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Levels/LevelData", order = 1)]

public class LevelData : ScriptableObject
{
    public int id;
    public int numberOfPairs;
    public List<CardData> cards;
    public float delayForShowing;
    public float timeUntilHide;
    public int forThreeStars;
    public int forTwoStars;
    public int forOneStar;
}
