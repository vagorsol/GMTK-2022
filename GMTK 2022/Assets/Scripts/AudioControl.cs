using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour{
    [SerializeField] private AudioMixer myAudioMixer;
    // Update is called once per frame
    public void setVolume(float sliderValue){
        myAudioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
