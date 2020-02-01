using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MotherSingleton<GameManager>
{
    public bool freeRoam;
    // Start is called before the first frame update
    void Start()
    {
        freeRoam = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
