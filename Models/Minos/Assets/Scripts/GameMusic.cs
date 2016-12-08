﻿using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour
{//GAME MUSIC FOR CONTROLLING CLIPS THAT DONT HAVE ANY LOOP
    public string state;
   // bool playedOnce;
    public AudioSource source;
    public AudioClip minotaurOne;
    public AudioClip minotaurTwo;
    public AudioClip minotaurThree;
    public AudioClip minotaurFour;
    public AudioClip doorOpen;
    //public bool stopPlaying;
    public bool firstBreathPlayedOnce;
    public bool secondBreathPlayedOnce;
    public bool thirdBreathPlayedOnce;
    public bool fourthBreathPlayedOnce;
    public bool doorOpenPlayedOnce;

    // Use this for initialization
    void Start ()
    {
        state = "normal";
        //playedOnce = false;
        //stopPlaying = false;
        firstBreathPlayedOnce = false;
        secondBreathPlayedOnce = false;
        thirdBreathPlayedOnce = false;
        fourthBreathPlayedOnce = false;
        doorOpenPlayedOnce = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (state == "normal")
        {
            normal();
        }
        if (state == "minotaur1")
        {
            minotaur1();
        }
        if (state == "minotaur2")
        {
            minotaur2();
        }
        if (state == "minotaur3")
        {
            minotaur3();
        }
        if (state == "minotaur4")
        {
            minotaur4();
        }
        if(state == "OpenDoor")
        {
            OpenDoor();
        }

    }
    public void changeState(string stateName)
    {
        state = stateName;
        print("current Music state for Minotaur breath is :" + stateName);
    }
    public void normal()
    {

    }
    public void minotaur1()
    {
        if (source.clip == minotaurOne)
        {
            if(!firstBreathPlayedOnce)
            {
                source.Play();
                firstBreathPlayedOnce = true;
            }
        }
        else
        {
            source.clip = minotaurOne;
            firstBreathPlayedOnce = false;
        }
    }
    public void minotaur2()
    {
        if (source.clip == minotaurTwo)
        {
            if (!secondBreathPlayedOnce)
            {
                source.Play();
                secondBreathPlayedOnce = true;
            }
        }
        else
        {
            source.clip = minotaurTwo;
            secondBreathPlayedOnce = false;
        }
    }
    public void minotaur3()
    {
        if (source.clip == minotaurThree)
        {
            if (!thirdBreathPlayedOnce)
            {
                source.Play();
                thirdBreathPlayedOnce = true;
            }
        }
        else
        {
            source.clip = minotaurThree;
            thirdBreathPlayedOnce = false;
        }
    }
    public void minotaur4()
    {
        if (source.clip == minotaurFour)
        {
            if (!fourthBreathPlayedOnce)
            {
                source.Play();
                fourthBreathPlayedOnce = true;
            }
        }
        else
        {
            source.clip = minotaurFour;
            fourthBreathPlayedOnce = false;
        }
    }
    public void OpenDoor()
    {
        if(source.clip == doorOpen)
        {
            if(!doorOpenPlayedOnce)
            {
                source.Play();
                doorOpenPlayedOnce = true;
            }
        }
        else
        {
            source.clip = doorOpen;
            doorOpenPlayedOnce = false;
        }
    }
}
