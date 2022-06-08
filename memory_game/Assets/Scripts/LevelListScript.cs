using System.Collections.Generic;
using UnityEngine;

public class LevelListScript : MonoBehaviour
{
    public Transform target;
    public List<Vector3> levelButtonPositions= new List<Vector3>();

    void Start()
    {
        string str = "{";
        LevelButtonScript[] list = target.GetComponentsInChildren<LevelButtonScript>();
        foreach (LevelButtonScript i in list)
        {
            GameObject button = i.gameObject;
            var buttonLocalPosition = button.transform.localPosition;
            levelButtonPositions.Add(buttonLocalPosition);
            str += "new Vector2" + buttonLocalPosition.ToString() + ",";
        }
        str += "}";
        Debug.Log(str);
    }
}
