using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

/*    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;*/

    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }
    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume",volumeSlider.value);
    }
}
