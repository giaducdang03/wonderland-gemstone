using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    ///*    public Sound[] musicSound, sfxSound;
    //    public AudioSource musicSource, sfxSource;*/
    //[SerializeField] Slider vfxSlider;
    //[SerializeField] Slider volumeSlider;
    //[SerializeField] AudioMixer mixer;
    //private const string vfxKey = "VFXVolume";

    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (!PlayerPrefs.HasKey("musicVolume"))
    //    {
    //        PlayerPrefs.SetFloat("musicVolume", 1);
    //        LoadVolume();
    //        vfxSlider.onValueChanged.AddListener(SetVfx);
    //        LoadVFX();
    //    }
    //    else
    //    {
    //        LoadVolume();
    //        vfxSlider.onValueChanged.AddListener(SetVfx);
    //        LoadVFX();
    //    }
    //}
    //public void SetVolume()
    //{
    //    Debug.Log("duma m");
    //    AudioListener.volume = volumeSlider.value;
    //}

    //public void LoadVolume()
    //{
    //    volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    //}

    //public void SaveVolume()
    //{
    //    PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    //}

    //public void SetVfx(float vfxValue)
    //{
    //    mixer.SetFloat("vfx", Mathf.Log10(vfxValue) * 20); // Assuming vfxSlider value is between 0 and 1
    //    SaveVFX(vfxValue);
    //}

    //private void SaveVFX(float vfxValue)
    //{
    //    PlayerPrefs.SetFloat(vfxKey, vfxValue);
    //    PlayerPrefs.Save();
    //}

    //private void LoadVFX()
    //{
    //    if (PlayerPrefs.HasKey(vfxKey))
    //    {
    //        float vfxValue = PlayerPrefs.GetFloat(vfxKey);
    //        vfxSlider.value = vfxValue;
    //        mixer.SetFloat("vfx", Mathf.Log10(vfxValue) * 20); // Assuming vfxSlider value is between 0 and 1
    //    }
    //    else
    //    {
    //        // Set a default vfx value if it's not saved yet
    //        float defaultVFX = 0.5f;
    //        vfxSlider.value = defaultVFX;
    //        mixer.SetFloat("vfx", Mathf.Log10(defaultVFX) * 20); // Assuming defaultVFX value is between 0 and 1
    //        SaveVFX(defaultVFX);
    //    }
    //}

    public static AudioManager Instance { get; private set; }

    [Header("Volume Settings")]
    [Range(0, 1)] public float masterVolume = 1f;
    [Range(0, 1)] public float musicVolume = 1f;
    [Range(0, 1)] public float sfxVolume = 1f;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("UI Elements")]
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateVolume();

        // Initialize sliders with current volume settings
        if (masterVolumeSlider != null)
            masterVolumeSlider.value = masterVolume;
        if (musicVolumeSlider != null)
            musicVolumeSlider.value = musicVolume;
        if (sfxVolumeSlider != null)
            sfxVolumeSlider.value = sfxVolume;

        // Add listeners to sliders
        if (masterVolumeSlider != null)
            masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        if (musicVolumeSlider != null)
            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        if (sfxVolumeSlider != null)
            sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        UpdateVolume();
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        UpdateVolume();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        if (musicSource != null)
        {
            musicSource.volume = masterVolume * musicVolume;
        }

        if (sfxSource != null)
        {
            sfxSource.volume = masterVolume * sfxVolume;
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    public void StopSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
        }
    }

}
