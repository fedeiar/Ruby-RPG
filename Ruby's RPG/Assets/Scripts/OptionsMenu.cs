using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private AudioSource music;
    private Slider slider;
	private LoadOnceAndForever manager;

    private void OnEnable() {
        music = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        manager = GameObject.Find("ObjectManager").GetComponent<LoadOnceAndForever>();
        slider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        slider.value = music.volume;
    }

    public void SetVolume(float volume) {
        music.volume = volume;
    }

    public void DeleteData() {
		manager.DeleteData();
    }
}   
