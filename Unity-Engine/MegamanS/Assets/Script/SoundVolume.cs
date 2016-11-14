using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{

    public AudioMixer mixerMusic;
    public Slider sliderMusic;
	// Use this for initialization
	void Start () {
        float mus = sliderMusic.value;
        mixerMusic.GetFloat("Musica", out mus);
	}
	
	// Update is called once per frame
	void Update () {
        mixerMusic.SetFloat("Musica", sliderMusic.value);
        
	}
}
