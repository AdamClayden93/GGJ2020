// Project:         
// Date created:	20/05/2019
// Date revised:	20/05/2019
// Original Author: Adam Clayden
// Notes:
// this should run absolutely first; use script-execution-order to do so.
// (of course, normally never use the script-execution-order feature,
// this is an unusual case, just for development.)
using UnityEngine;

// Automatically loads our _preload scene so we don't have to!
public class loadPreLoad : MonoBehaviour
{
    void Awake()
    {
        GameObject check = GameObject.Find("_aGeneralBehaviours");
        if (check == null)
        { UnityEngine.SceneManagement.SceneManager.LoadScene(0); }
    }
}