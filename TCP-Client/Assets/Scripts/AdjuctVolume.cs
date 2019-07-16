using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjuctVolume : MonoBehaviour
{
    private AudioSource bgm;
    public AudioClip music;
    public Slider slider;


    void Start()
    {
        bgm = this.gameObject.GetComponent<AudioSource>();
        bgm.loop = true;
        bgm.volume = 0.25f;
        bgm.clip = music;
        bgm.Play();
    }


    void Update()
    {
        adjustVolume(slider.value);
    }



    public void adjustVolume(float value)
    {
        bgm.volume = value;
    }

    //void increaseBgm(int value)
    //{

    //}
    //void decreaseBgm(int value )
    //{

    //}


}
