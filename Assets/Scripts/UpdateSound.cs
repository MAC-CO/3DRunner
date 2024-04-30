using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSound : MonoBehaviour
{
    //List<AudioSource> sfx = new List<AudioSource>();

    public void Start()
    {
        //AudioSource[] allAS = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        //for (int i = 1; i < allAS.Length; i++)
        //{
        //    sfx.Add(allAS[i]);
        //}


        Slider sfxSlider = this.GetComponent<Slider>();

        if (PlayerPrefs.HasKey("sfxvolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxvolume");
            UpdateSFXVolume(sfxSlider.value);
        }
        else
        {
            sfxSlider.value = 1;
            UpdateSFXVolume(1);
        }
    }

    public void UpdateSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("sfxvolume", value);
        //foreach (AudioSource s in sfx)
        //{
        //    s.volume = value;
        //}
    }
}
