using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] Slider volumeSlider;
    //[SerializeField] Slider vfxSlider; //used for adjusting visual effects
    [SerializeField] AudioMixer mixer; // used to control audio settings 

    //Strings used as keys for saving and loading player preferences.
    //private const string VolumeKey = "Volume";
    //private const string VfxKey = "VFX";
    private const float DefaultVolume = 0.5f;
    private const float DefaultVFX = 0.5f;
    private void Start()
    {
        //InitializeSlider(volumeSlider, VolumeKey, "volume", DefaultVolume);
        //InitializeSlider(vfxSlider, VfxKey, "vfx", DefaultVFX);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MoveToSetting()
    {
        SceneManager.LoadScene("Settings");
    }

    // Update is called once per frame
    public void Quit()
	{
		Application.Quit();
	}

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    //Này là set up cho Volume 
    /* public void SetVolume()
     {
         float volumeValue = volumeSlider.value;
         mixer.SetFloat("volume", volumeValue);
         SaveVolume(volumeValue);
     }

     private void SaveVolume(float volumeValue)
     {
         PlayerPrefs.SetFloat(volumeKey, volumeValue);
         PlayerPrefs.Save();
     }

     private void LoadVolume()
     {
         if (PlayerPrefs.HasKey(volumeKey))
         {
             float volumeValue = PlayerPrefs.GetFloat(volumeKey);
             volumeSlider.value = volumeValue;
             mixer.SetFloat("volume", volumeValue);
         }
         else
         {
             // Set a default volume value if it's not saved yet
             float defaultVolume = 0.5f;
             volumeSlider.value = defaultVolume;
             mixer.SetFloat("volume", defaultVolume);
             SaveVolume(defaultVolume);
         }
     }

     public void SetVfx()
     {
         float vfxValue = vfxSlider.value;
         mixer.SetFloat("vfx", vfxValue);
         SaveVFX(vfxValue);
     }

     private void SaveVFX(float vfxValue)
     {
         PlayerPrefs.SetFloat(vfxKey, vfxValue);
         PlayerPrefs.Save();
     }

     private void LoadVFX()
     {
         if (PlayerPrefs.HasKey(vfxKey))
         {
             float vfxValue = PlayerPrefs.GetFloat(vfxKey);
             vfxSlider.value = vfxValue;
             mixer.SetFloat("vfx", vfxValue);
         }
         else
         {
             // Set a default vfx value if it's not saved yet
             float defaultVFX = 0.5f;
             vfxSlider.value = defaultVFX;
             mixer.SetFloat("vfx", defaultVFX);
             SaveVFX(defaultVFX);
         }
     }*/
    //public void SetVolume()
    //{
    //    SetAudioParameter(volumeSlider, VolumeKey, "volume");
    //}

    //public void SetVfx()
    //{
    //    SetAudioParameter(vfxSlider, VfxKey, "vfx");
    //}

    public void MoveToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    private void InitializeSlider(Slider slider, string prefKey, string mixerParam, float defaultValue)
    {
        float value = PlayerPrefs.HasKey(prefKey) ? PlayerPrefs.GetFloat(prefKey) : defaultValue;
        slider.value = value;
        mixer.SetFloat(mixerParam, value);
        if (!PlayerPrefs.HasKey(prefKey))
        {
            SavePreference(prefKey, value);
        }
    }

    private void SetAudioParameter(Slider slider, string prefKey, string mixerParam)
    {
        float value = slider.value;
        mixer.SetFloat(mixerParam, value);
        SavePreference(prefKey, value);
    }

    private void SavePreference(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}
