using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScript : MonoBehaviour
{
    LevelData level;
    [HideInInspector] public List<TileScript> tilesRef;
    public GameObject tilePrefab;
    public EndPanelScript endPanel;
    public RectTransform gridRef;
    public GridLayoutGroup gridConfigs;
    private List<TileScript> selectedOnes = new List<TileScript>(2);
    private int matches; //Rider told me that initializing field with default value is redundant :P
    private int attempts;

    void Start()
    {
        level = LevelManager.instance.GetCurrentLevel();
        Initialize();
        BuildGrid();
        StartGame();
    }

    private void Initialize()
    {
        endPanel.gameObject.SetActive(false);
    }

    List<CardData> RandomCards()
    {
        List<CardData> newList = new List<CardData>(level.cards);
        List<CardData> result = new List<CardData>();
        for (var i = 0; i < level.numberOfPairs; i++)
        {
            var index = Random.Range(0, newList.Count);
            CardData sortedCard = newList[index];
            result.Add(sortedCard);
            result.Add(sortedCard);
            newList.Remove(sortedCard);
        }
        result.Sort((a, b) => 1 - 2 * Random.Range(0, 2));
        return result;
    }

    void BuildGrid()
    {
        level = LevelManager.instance.GetCurrentLevel(); //Retirei o tipo de level aqui
        List<CardData> sortedCards = RandomCards();
        for (var i = 0; i < sortedCards.Count; i++)
        {
            var tile = Instantiate(tilePrefab, gridRef);
            var tileSymbol = tile.GetComponent<TileScript>();
            tileSymbol.SetData(sortedCards[i]);
            tileSymbol.onClickHandler += OnItemClick;
            tilesRef.Add(tileSymbol);
        }        
    }
   
    private void OnItemClick(TileScript obj)
    {
        if (obj.state == false)
        {
            selectedOnes.Add(obj);
            obj.Show();           
        }
        if (selectedOnes.Count == 2)
        {
            attempts++;
            TilesVerifier();
            EndGameVerifier();
        }
    }

    void StartGame()
    {
        float total = level.delayForShowing + level.timeUntilHide;
        for (var i = 0; i < tilesRef.Count; i++)
        {
            var script = tilesRef[i];
            script.ShowAndHide(level.delayForShowing, level.timeUntilHide);            
        }
        StartCoroutine(EnableInteractions(total));      
    }
    
    void EndGame()
    {
        bool hasNextLevel = LevelManager.instance.GetNextLevel(); //? true : false;
        var result = GetResult();
        PlayerProgress.instance.SetLevelScore(level.id, result);
        if (result > 0)
        {
            PlayerProgress.instance.SetGameProgress(LevelManager.instance.current + 1);
        }
        endPanel.gameObject.SetActive(true);
        endPanel.onRestartClickHandler += OnRestartClickHandler;
        endPanel.onNextClickHandler += OnNextClickHandler; 
        endPanel.SetResult(result, attempts, hasNextLevel);

    }    

    private void OnRestartClickHandler()
    {
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.GameScene);
    }

    private void OnNextClickHandler()
    {
        LevelManager.instance.SetNextLevel();
        ChangeSceneScript.instance.ChangeToScene(SceneIdEnum.GameScene);
    }

    IEnumerator EnableInteractions(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (var i = 0; i < tilesRef.Count; i++)
        {
            tilesRef[i].AddListeners();
        }
    }

    void TilesVerifier()
    {
        if (selectedOnes[0].card.id == selectedOnes[1].card.id)
        {
            Correct();
        }
        else
        {
            Error();
        }
        selectedOnes.Clear();        
    }

    void Correct()
    {
        matches++;
        var first = selectedOnes[0];
        var second = selectedOnes[1];
        DeleteTiles(first, second);
    }

    void Error()
    {
        selectedOnes[0].Invoke("Hide", 0.4f);
        selectedOnes[1].Invoke("Hide", 0.4f);
        SoundScript.instance.PlayWrongSfx();
    }
    void EndGameVerifier()
    {
        if (matches == level.numberOfPairs)
        {
            EndGame();
        }
    }

    void DeleteTiles(TileScript one, TileScript two)
    {
        tilesRef.Remove(one);
        tilesRef.Remove(two);
        one.Clear();
        two.Clear();
        SoundScript.instance.PlayMatchSfx();
    }

    private int GetResult()
    {
        int result = 0;
        if (attempts <= level.forThreeStars)
        {
            SoundScript.instance.PlaySuccessSfx();
            result = 3;
        } else if (attempts <= level.forTwoStars) 
        {
            result = 2;
            SoundScript.instance.PlaySuccessSfx();
        } else if (attempts <= level.forOneStar)
        {
            result = 1;
            SoundScript.instance.PlaySuccessSfx();
        } else if (attempts > level.forOneStar) 
        {
            result = 0;
            SoundScript.instance.PlayFailSfx();
        }
        return result;
    }
}
