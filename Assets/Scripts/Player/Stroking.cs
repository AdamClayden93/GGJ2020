using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroking : MotherSingleton<Stroking>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.inPhaseTwo)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    if (Vector2.Distance(GOReferences.Instance.mainCam.ScreenToWorldPoint(touch.position), Cat.Instance.fleabagLocations[Cat.Instance.fleabagIndex].position) < 2f)
                    {
                        Handheld.Vibrate();
                        if(touch.phase == TouchPhase.Ended)
                        {
                            // START FLEA GAME!
                        }
                        // some audio and some animation pls
                        // found the fleas!
                    }
                }
            }
            //if (touch.phase == TouchPhase.Moved)
            //{
            /*print("mouse:" + GOReferences.Instance.mainCam.ScreenToWorldPoint(Input.mousePosition) + " cat: " + Cat.Instance.fleabagLocations[Cat.Instance.fleabagIndex].position);
                if (Vector2.Distance(GOReferences.Instance.mainCam.ScreenToWorldPoint(Input.), Cat.Instance.fleabagLocations[Cat.Instance.fleabagIndex].position) < 2f)
                {
                print("NICE");
                    Handheld.Vibrate();
                    // some audio and some animation pls
                    // found the fleas!
                }*/
            //}
        }
        
    }
}
