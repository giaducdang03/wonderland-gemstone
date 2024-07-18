using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public Button musicTurnOff, musicTurnOn, sfxTurnOff, sfxTurnOn;
    private bool isMusicMute = false;
    private bool isSFXMute = false;
    private float sfxVolume;
    private float musicVolume;

    private void Start()
    {
        musicVolume = AudioManager.Instance.GetMusicVolume();
        sfxVolume = AudioManager.Instance.GetSFXVolume();
        UpdateUI();
    }

    public void ToggleMusic()
    {
        isMusicMute = AudioManager.Instance.ToggleMusic();
        UpdateUI();
    }

    public void ToggleSFX()
    {
        isSFXMute = AudioManager.Instance.ToggleSFX();
        UpdateUI();
    }

    public void MusicVolume()
    {

        if (musicSlider.value != 0)
        {
            AudioManager.Instance.MusicVolume(musicSlider.value);
            musicVolume = musicSlider.value;
        }
        else
        {
            isMusicMute = true;
        }

    }

    public void SFXVolume()
    {

        if (sfxSlider.value != 0)
        {
            AudioManager.Instance.SFXVolume(sfxSlider.value);
            sfxVolume = sfxSlider.value;
        }
        else
        {
            isSFXMute = true;
        }

    }
    private void UpdateUI()
    {
        musicTurnOn.gameObject.SetActive(!isMusicMute);
        musicTurnOff.gameObject.SetActive(isMusicMute);
        sfxTurnOff.gameObject.SetActive(isSFXMute);
        sfxTurnOn.gameObject.SetActive(!isSFXMute);
        if (isMusicMute)
        {
            musicSlider.value = 0;
        }
        else
        {
            musicSlider.value = musicVolume;
        }
        if (isSFXMute)
        {
            sfxSlider.value = 0;
        }
        else
        {
            sfxSlider.value = sfxVolume;
        }
    }

    public void LoadScreen(int screenId)
    {
        SceneManager.LoadScene(screenId);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
