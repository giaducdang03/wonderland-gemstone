using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

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

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, match => match.name == name);
        if (s == null)
        {
            Debug.Log("sound " + name + " not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, match => match.name == name);
        if (s == null)
        {
            Debug.Log("sound " + name + " not found!");
        }
        else
        {
            sfxSource.pitch = 1;
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void StartPlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, match => match.name == name);
        if (s == null)
        {
            Debug.Log("sound " + name + " not found!");
        }
        else
        {
            sfxSource.pitch = 1;
            sfxSource.clip = s.clip;
            sfxSource.loop = true;
            sfxSource.Play();
        }
    }

    public void StopPlaySFX()
    {
        sfxSource.loop = false;
        sfxSource.Stop();
    }

    public bool ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        return musicSource.mute;
    }

    public bool ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        return sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    public float GetMusicVolume()
    {
        return musicSource.volume;
    }
    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }
    public void PlaySFXRandomPitch(string name, float start = 0, float end = 3)
    {
        Sound s = Array.Find(sfxSounds, match => match.name == name);
        if (s == null)
        {
            Debug.Log("sound " + name + " not found!");
        }
        else
        {
            float e = UnityEngine.Random.Range(start, end);
            sfxSource.pitch = e;
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }


    }

}
