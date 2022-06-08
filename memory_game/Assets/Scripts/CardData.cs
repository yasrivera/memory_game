using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/Card", order = 1)]

public class CardData : ScriptableObject 
{
    public int id;
    public Sprite sprite;
}
