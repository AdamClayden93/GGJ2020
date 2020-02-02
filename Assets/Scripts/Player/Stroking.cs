using UnityEngine;
using UnityEngine.SceneManagement;

public class Stroking : MotherSingleton<Stroking>
{
    AudioClip[] purrArray = new AudioClip[3];
    bool lerpCamera;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.Instance.catDeterioration)
        {
            case 2:
                MeowManager.Instance.cLCat = MeowManager.Instance.chCat;
                break;
            case 4:
                MeowManager.Instance.cLCat = MeowManager.Instance.cdCat;
                break;
            default:
                MeowManager.Instance.cLCat = MeowManager.Instance.cLCat;
                break;
        }
        lerpCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lerpCamera)
        {
            //if (GameManager.Instance.inPhaseTwo)
            //{
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    if (Vector2.Distance(Input.mousePosition, GOReferences.Instance.mainCam.WorldToScreenPoint(Cat.Instance.fleabagLocations[Cat.Instance.fleabagIndex].position)) < 40f)
                    {
                        GameManager.Instance.catDeterioration += 1;
                        MeowManager.Instance.PlayRandomPurr();
                        Vibration.Vibrate(MeowManager.Instance.ObtainPurrLength());
                        //Handheld.Vibrate();
                        lerpCamera = true;
                        FadeAdjustment.Instance.TriggerFading(GameManager.Instance.fadePoint);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        // some audio and some animation pls
                        // found the fleas!
                    }
                }
            }
        }
        else
        {
            //GOReferences.Instance.mainCam.transform.rotation = Quaternion.Lerp(GOReferences.Instance.mainCam.transform.rotation, Quaternion.Euler(newPos), Time.deltaTime * 5);
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
        //}

    }
}
