using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelScript : MonoBehaviour
{
    /* Buttons of the panel */
    public Button returnButton;
    public CanvasGroup settingsPanel;

    /* Music options */
    public Toggle toggleBgmState;
    public Slider bgmSliderVolume;

    /* Sfx options */
    public Toggle toggleSfxState;
    public Slider sfxSliderVolume;

    /* Language options */
    public Dropdown dropdownLanguage;

    void Awake()
    {
        returnButton.onClick.AddListener(OnClickReturn);
        ConfigToggle();
        ConfigDropdown();
    }

    void Start()
    {
        OnMusicToggleChange(SoundScript.instance.IsMusicStateOn());
        OnSfxToggleChange(SoundScript.instance.IsSfxStateOn());
    }

    private void OnClickReturn()
    {
        SoundScript.instance.PlayClickSfx();
        PanelScript.instance.TogglePanelState(settingsPanel);
    }

    void enableSlider(Slider slider)
    {
        slider.gameObject.SetActive(true);
    }

    void disableSlider(Slider slider)
    {
        slider.gameObject.SetActive(false);
    }

    void OnMusicSliderChange(float volume)
    {
        SoundScript.instance.SetBgmVolume(volume);
    }

    void OnSfxSliderChange(float volume)
    {
        SoundScript.instance.SetSfxVolume(volume);
    }

    void ConfigToggle()
    {
        toggleBgmState.onValueChanged.AddListener(OnMusicToggleChange);
        toggleSfxState.onValueChanged.AddListener(OnSfxToggleChange);
    }

    void OnMusicToggleChange(bool toggleState)
    {
        if (toggleState)
        {
            enableSlider(bgmSliderVolume);
            bgmSliderVolume.onValueChanged.AddListener(OnMusicSliderChange);
            bgmSliderVolume.value = SoundScript.instance.GetBgmVolume();
        }
        else
        {
            toggleBgmState.isOn = false;
            disableSlider(bgmSliderVolume);
            bgmSliderVolume.onValueChanged.RemoveListener(OnMusicSliderChange);
        }
        SoundScript.instance.SetMusicState(toggleState);
    }

    void OnSfxToggleChange(bool toggleState)
    {
        if (toggleState)
        {
            enableSlider(sfxSliderVolume);
            sfxSliderVolume.onValueChanged.AddListener(OnSfxSliderChange);
            sfxSliderVolume.value = SoundScript.instance.GetSfxVolume();
        }
        else
        {
            toggleSfxState.isOn = false;
            disableSlider(sfxSliderVolume);
            sfxSliderVolume.onValueChanged.RemoveListener(OnSfxSliderChange);
        }
        SoundScript.instance.SetSfxState(toggleState);
    }

    void ConfigDropdown()
    {
        var options = new List<Dropdown.OptionData>() {
            new Dropdown.OptionData("português"),
            new Dropdown.OptionData("inglês"),
            new Dropdown.OptionData("espanhol"),
        };
        dropdownLanguage.ClearOptions();
        dropdownLanguage.AddOptions(options); //passar a lista toda
        dropdownLanguage.onValueChanged.AddListener(OnDropdownChange);
    }

    void OnDropdownChange(int arg0)
    {
        //Debug.Log("Index dropdown: " + arg0);
        //Debug.Log("Texto do item: " + dropdownLanguage.options[arg0].text);
    }
}
