using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public static ChangeSceneScript instance;

    void Awake()
    {
        if (ChangeSceneScript.instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void ChangeToScene(SceneIdEnum sceneNumber)
    {
        SceneManager.LoadScene((int) sceneNumber);
    }
}
public enum SceneIdEnum
{
    SplashScene = 0,
    LevelMapScene = 1,
    GameScene = 2
}
