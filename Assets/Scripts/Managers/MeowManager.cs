using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowManager : MotherSingleton<MeowManager>
{
    public AudioClip[] meows;
    public AudioClip[] purrs;
    AudioSource myAsource;
    long purrLength;
    // Start is called before the first frame update
    void Start()
    {
        myAsource = GetComponent<AudioSource>();
    }

    public void PlayStartMeow()
    {
        myAsource.PlayOneShot(meows[0]);
    }

    public void PlayRandomMeow()
    {
        myAsource.PlayOneShot(meows[Random.Range(0,4)]);
    }

    public void GenerateNewPurr()
    {
        purrLength = Random.Range(0, purrs.Length);
    }

    public long ObtainPurrLength()
    {
        return purrLength * 1000;
    }

    public void PlayRandomPurr()
    {
        GenerateNewPurr();
        myAsource.PlayOneShot(purrs[(int)purrLength]);
    }
}
