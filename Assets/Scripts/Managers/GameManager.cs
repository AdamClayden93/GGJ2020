﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MotherSingleton<GameManager>
{
    public bool gameStart , inPhaseOne, freezeControls, inPhaseTwo;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        inPhaseOne = false;
        inPhaseTwo = false;
        freezeControls = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
