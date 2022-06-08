using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static SoundScript instance;
    public AudioListener listener;
    public AudioSource sourceSfx;
    public AudioSource sourceBgm;
    public AudioClip clickSound;
    public AudioClip flipCardSound;
    public AudioClip correctMatchSound;
    public AudioClip wrongMatchSound;
    public AudioClip levelCompletedSound;
    public AudioClip failSound;
    public bool musicState = true;
    public bool sfxState = true;

    void Awake()
    {
        //Isso aqui estava dando errado adicionei (&& instance != this) para manter
        //a referência certa do audio source.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(instance);
        SetBgmVolume(1f);
        SetSfxVolume(1f);
    }

    public void PlayBgm()
    {
        if (!IsMusicStateOn() | sourceBgm.isPlaying) return;
        sourceBgm.Play();
    }

    //Duas funções para momentos diferentes :)
    void PlaySfx(AudioClip clip)
    {
        if (!IsSfxStateOn()) return;
        sourceSfx.mute = false;
        sourceSfx.PlayOneShot(clip);
    }

    void PlaySfx()
    {
        sourceSfx.mute = false;
    }

    public void PlayClickSfx()
    {
        PlaySfx(clickSound);
    }

    public void PlayFlipSfx()
    {
        PlaySfx(flipCardSound);
    }

    public void PlayMatchSfx()
    {
        PlaySfx(correctMatchSound);
    }

    public void PlayWrongSfx()
    {
        PlaySfx(wrongMatchSound);
    }

    public void PlaySuccessSfx()
    {
        PlaySfx(levelCompletedSound);
    }

    public void PlayFailSfx()
    {
        PlaySfx(failSound);
    }

    public void SetBgmVolume(float volume)
    {
        sourceBgm.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        sourceSfx.volume = volume;
    }

    public float GetBgmVolume()
    {
        return sourceBgm.volume;
    }

    public float GetSfxVolume()
    {
        return sourceSfx.volume;
    }

    public void StopBgm()
    {
        sourceBgm.Stop();
        musicState = false;
    }

    public void StopSfx()
    {
        sourceSfx.mute = true;
        sfxState = false;
    }

    public void SetMusicState(bool mscState)
    {
        this.musicState = mscState;
        if (this.musicState)
        {
            PlayBgm();
        } else
        {
            StopBgm();
        }
    }
    public void SetSfxState(bool fxState)
    {
        this.sfxState = fxState;
        if (this.sfxState)
        {
            PlaySfx();
        }
        else
        {
            StopSfx();
        }
    }

    public bool IsSfxStateOn()
    {
        return sfxState;
    }

    public bool IsMusicStateOn()
    {
        return musicState;
    }
}
