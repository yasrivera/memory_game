using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] public List<LevelData> levelList = new List<LevelData>();
    [HideInInspector] public int current;    

    void Awake()
    {
        if (LevelManager.instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public LevelData GetCurrentLevel()
    {
        return levelList[current];
    }

    public void SetCurrentLevel(int levelId) //Novo
    {
        this.current = levelId;
    }

    public LevelData GetNextLevel()
    {
        int next = current + 1;
        if (next < levelList.Count)
        {
            return levelList[next];
        } else {
            return null;
        }
    }

    public void SetNextLevel()
    {
        this.current += 1;
        SetCurrentLevel(this.current);
    }    
}
