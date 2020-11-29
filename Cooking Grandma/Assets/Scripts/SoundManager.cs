using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip chopSound, cookSound, boilSound, trumpetSound, GordanRamsaySound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        chopSound = Resources.Load<AudioClip>("Chop Sound Effect");
        cookSound = Resources.Load<AudioClip>("Cook Sound Effect");
        boilSound = Resources.Load<AudioClip>("Boil Sound Effect");
        trumpetSound = Resources.Load<AudioClip>("Trumpet Sound Effect");
        GordanRamsaySound = Resources.Load<AudioClip>("Gordan Ramsay One");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch(clip) {
            case "chop":
                audioSrc.PlayOneShot(chopSound);
                break;
            case "cook":
                audioSrc.PlayOneShot(cookSound);
                break;
            case "boil":
                audioSrc.PlayOneShot(boilSound);
                break;
            case "trumpet":
                audioSrc.PlayOneShot(trumpetSound);
                break;
            case "fail":
                audioSrc.PlayOneShot(GordanRamsaySound);
                break;
        }

    }
}
