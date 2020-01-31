// Project:         TwinstickChrisClayden
// Date created:	20/05/2019
// Date revised:	20/05/2019
// Original Author: Adam Clayden
// Notes: This GameObject acts as a hub for all general behaviours (sound effects, scoring etc)
using UnityEngine;

// Makes our central manager object persist across all scenes
// it's born in the _preload scene
public class DDOL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
