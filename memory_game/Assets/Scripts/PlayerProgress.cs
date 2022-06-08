using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance;
    private string keyCurrentLevel = "current";
    private string keyLevelScore = "scoreOfLevel{0}";

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }
    
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void SetGameProgress(int level)
    {
        int currentLevel = instance.GetGameProgress();
        if (currentLevel < level)
        {
            PlayerPrefs.SetInt(keyCurrentLevel, level);
        }        
    }

    public int GetGameProgress()
    {
        return PlayerPrefs.GetInt(keyCurrentLevel, 0);
    }

    public int GetLevelScore(int levelId)
    {
        var key = string.Format(keyLevelScore, levelId);
        return PlayerPrefs.GetInt(key, 0);
    }

    public void SetLevelScore(int levelId, int score)
    {
        //string.Format("Test: {0}, {1}", 10, 20)
        int levelScore = instance.GetLevelScore(levelId);
        if (levelScore < score)
        {
            var key = string.Format(keyLevelScore, levelId);
            PlayerPrefs.SetInt(key, score);
        }        
    }
}
