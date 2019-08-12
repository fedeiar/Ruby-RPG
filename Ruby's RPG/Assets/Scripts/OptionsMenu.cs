using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private AudioSource music;
    private Slider slider;
   

    private void OnEnable() {
        MusicPlayer mp = MusicPlayer._instance;
        music = mp.GetComponent<AudioSource>();

        Debug.Log("enabled slider");
        slider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        slider.value = music.volume;
    }

    public void SetVolume(float volume) {
        music.volume = volume;
    }
}   
