using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public static PanelScript instance;

    void Awake()
    {
        if (PanelScript.instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

   public void TogglePanelState(CanvasGroup panel)
   {
        if (panel.alpha == 0 && panel.interactable == false)
        {
            Show(panel);
        }
        else
        {
            Hide(panel);
        }
    }

    public PanelAnimation HasPanelAnimation(CanvasGroup cg)
	{
        return cg.gameObject.GetComponent<PanelAnimation>();
	}

    public void Show(CanvasGroup panel)
    {
        var animation = HasPanelAnimation(panel);
        if (animation)  animation.Show();
            panel.alpha = 1;
            panel.interactable = true;
            panel.blocksRaycasts = true;
    }

    public void Hide(CanvasGroup panel) 
    {
        var animation = HasPanelAnimation(panel);
        if (animation)  animation.Hide();
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
    }

}
