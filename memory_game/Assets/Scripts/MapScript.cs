using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapScript : MonoBehaviour
{
    public static MapScript instance;
    public RectTransform contentTransform;
    public GameObject levelButtonPrefab;
    public GameObject backgroundPrefab;
    public RectTransform bgContainer;
    [HideInInspector] public List<GameObject> bgObjects;
    public List<LevelButtonScript> levelButtonScripts;
    public RectTransform itemsContainer;
    private List<Vector2> listWonderful = new List<Vector2>(){ 
        new Vector3(572.0f, -118.0f, 0.0f),
        new Vector3(735.0f, -543.0f, 0.0f),
        new Vector3(468.0f, -868.0f, 0.0f),
        new Vector3(790.0f, -1278.0f, 0.0f),
        new Vector3(735.0f, -2493.0f, 0.0f),
        new Vector3(790.0f, -3228.0f, 0.0f),
        new Vector3(572.0f, -2068.0f, 0.0f),
        new Vector3(468.0f, -2818.0f, 0.0f),
        new Vector3(468.0f, -4718.0f, 0.0f),
        new Vector3(735.0f, -4393.0f, 0.0f),
        new Vector3(790.0f, -5128.0f, 0.0f),
        new Vector3(572.0f, -3968.0f, 0.0f),
        new Vector3(735.0f, -6302.0f, 0.0f),
        new Vector3(790.0f, -7037.0f, 0.0f),
        new Vector3(468.0f, -6627.0f, 0.0f),
        new Vector3(572.0f, -5877.0f, 0.0f) };

    void Start()
    {
        listWonderful = listWonderful.OrderBy(position => position.y).Reverse().ToList(); 
        //ordenar listas de objetos mais complexos com o Linq
        instance = this;
        InstantiatingBackground();
        InstantiatingLevels();     
    }

    private void InstantiatingBackground()
    {
        LevelManager inst = LevelManager.instance;
        for (var i = 0; i < inst.levelList.Count; i += 4) //4 > qtd de levels por bg
        {
            var bgObject = Instantiate(backgroundPrefab, bgContainer.transform);
            bgObjects.Add(bgObject);
        }        
    }

    private void InstantiatingLevels()
    {
        LevelManager inst = LevelManager.instance;
        for (var i = 0; i < inst.levelList.Count; i++)
        {
            var levelButton = Instantiate(levelButtonPrefab, itemsContainer.transform);
            levelButton.name = "Botão " + inst.levelList[i].id + 1;
            levelButton.transform.localPosition = listWonderful[i];
            var script = levelButton.GetComponent<LevelButtonScript>();
            levelButtonScripts.Add(script);
            script.SetLevelNumber(inst.levelList[i].id);
            script.onSelectHandler += OnClickLevel;
            // Setando o score visual das estrelas no mapa
            int levelScore = PlayerProgress.instance.GetLevelScore(inst.levelList[i].id);
            script.SetVisualScore(levelScore);
            if (i > PlayerProgress.instance.GetGameProgress())
            {
                script.BlockInteractions();
            }
        }
    }

    private void OnClickLevel(int levelId) //Novo
    {
        SoundScript.instance.PlayClickSfx();
        LevelManager.instance.SetCurrentLevel(levelId);
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.GameScene);
    }

    void Update()
    {
        contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, bgContainer.sizeDelta.y);
    }
}
