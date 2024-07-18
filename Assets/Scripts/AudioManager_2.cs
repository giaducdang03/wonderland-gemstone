//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class AudioManager2 : MonoBehaviour
//{
//    //public static AudioManager Instance;

//    //public Sound[] musicSounds, sfxSounds;
//    //public AudioSource musicSource, sfxSource;

//    //private void Awake()
//    //{
//    //    if (Instance == null)
//    //    {
//    //        Instance = this;
//    //        DontDestroyOnLoad(gameObject);
//    //    }
//    //    else
//    //    {
//    //        Destroy(gameObject);
//    //    }
//    //}

//    //public void PlayMusic(string name)
//    //{
//    //    Sound s = Array.Find(musicSounds, match => match.name == name);
//    //    if (s == null)
//    //    {
//    //        Debug.Log("sound " + name + " not found!");
//    //    }
//    //    else
//    //    {
//    //        musicSource.clip = s.clip;
//    //        musicSource.Play();
//    //    }
//    //}

//    //public void PlaySFX(string name)
//    //{
//    //    Sound s = Array.Find(sfxSounds, match => match.name == name);
//    //    if (s == null)
//    //    {
//    //        Debug.Log("sound " + name + " not found!");
//    //    }
//    //    else
//    //    {
//    //        sfxSource.pitch = 1;
//    //        sfxSource.clip = s.clip;
//    //        sfxSource.PlayOneShot(s.clip);
//    //    }
//    //}

//    //public void StartPlaySFX(string name)
//    //{
//    //    Sound s = Array.Find(sfxSounds, match => match.name == name);
//    //    if (s == null)
//    //    {
//    //        Debug.Log("sound " + name + " not found!");
//    //    }
//    //    else
//    //    {
//    //        sfxSource.pitch = 1;
//    //        sfxSource.clip = s.clip;
//    //        sfxSource.loop = true;
//    //        sfxSource.Play();
//    //    }
//    //}

//    //public void StopPlaySFX()
//    //{
//    //    sfxSource.loop = false;
//    //    sfxSource.Stop();
//    //}

//    //public bool ToggleMusic()
//    //{
//    //    musicSource.mute = !musicSource.mute;
//    //    return musicSource.mute;
//    //}

//    //public bool ToggleSFX()
//    //{
//    //    sfxSource.mute = !sfxSource.mute;
//    //    return sfxSource.mute;
//    //}

//    //public void MusicVolume(float volume)
//    //{
//    //    musicSource.volume = volume;
//    //}

//    //public void SFXVolume(float volume)
//    //{
//    //    sfxSource.volume = volume;
//    //}
//    //public float GetMusicVolume()
//    //{
//    //    return musicSource.volume;
//    //}
//    //public float GetSFXVolume()
//    //{
//    //    return sfxSource.volume;
//    //}
//    //public void PlaySFXRandomPitch(string name, float start = 0, float end = 3)
//    //{
//    //    Sound s = Array.Find(sfxSounds, match => match.name == name);
//    //    if (s == null)
//    //    {
//    //        Debug.Log("sound " + name + " not found!");
//    //    }
//    //    else
//    //    {
//    //        float e = UnityEngine.Random.Range(start, end);
//    //        sfxSource.pitch = e;
//    //        sfxSource.clip = s.clip;
//    //        sfxSource.PlayOneShot(s.clip);
//    //    }


//    //}

//    public static AudioManager2 Instance { get; private set; }

//    [Header("Volume Settings")]
//    [Range(0, 1)] public float masterVolume = 1f;
//    [Range(0, 1)] public float musicVolume = 1f;
//    [Range(0, 1)] public float sfxVolume = 1f;

//    [Header("Audio Sources")]
//    public AudioSource musicSource;
//    public AudioSource sfxSource;

//    [Header("UI Elements")]
//    public Slider masterVolumeSlider;
//    public Slider musicVolumeSlider;
//    public Slider sfxVolumeSlider;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    private void Start()
//    {
//        UpdateVolume();

//        // Initialize sliders with current volume settings
//        if (masterVolumeSlider != null)
//            masterVolumeSlider.value = masterVolume;
//        if (musicVolumeSlider != null)
//            musicVolumeSlider.value = musicVolume;
//        if (sfxVolumeSlider != null)
//            sfxVolumeSlider.value = sfxVolume;

//        // Add listeners to sliders
//        if (masterVolumeSlider != null)
//            masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
//        if (musicVolumeSlider != null)
//            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
//        if (sfxVolumeSlider != null)
//            sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
//    }

//    public void SetMasterVolume(float volume)
//    {
//        masterVolume = volume;
//        UpdateVolume();
//    }

//    public void SetMusicVolume(float volume)
//    {
//        musicVolume = volume;
//        UpdateVolume();
//    }

//    public void SetSFXVolume(float volume)
//    {
//        sfxVolume = volume;
//        UpdateVolume();
//    }

//    private void UpdateVolume()
//    {
//        if (musicSource != null)
//        {
//            musicSource.volume = masterVolume * musicVolume;
//        }

//        if (sfxSource != null)
//        {
//            sfxSource.volume = masterVolume * sfxVolume;
//        }
//    }

//    public void PlayMusic(AudioClip clip, bool loop = true)
//    {
//        if (musicSource != null)
//        {
//            musicSource.clip = clip;
//            musicSource.loop = loop;
//            musicSource.Play();
//        }
//    }

//    public void PlaySFX(AudioClip clip)
//    {
//        if (sfxSource != null)
//        {
//            sfxSource.PlayOneShot(clip, sfxVolume);
//        }
//    }

//    public void StopMusic()
//    {
//        if (musicSource != null)
//        {
//            musicSource.Stop();
//        }
//    }

//    public void StopSFX()
//    {
//        if (sfxSource != null)
//        {
//            sfxSource.Stop();
//        }
//    }

//}
