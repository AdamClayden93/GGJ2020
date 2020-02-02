using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stroking : MotherSingleton<Stroking>
{
    WaitForSeconds fourSec = new WaitForSeconds(4.0f);
    AudioClip[] purrArray = new AudioClip[3];
    public bool lerpCamera;
    public Animator panelAnim;
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
                GameManager.Instance.forCoroutine = true;
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
        if (GameManager.Instance.catDeterioration < 4)
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
        }else
        {
            GameManager.Instance.freezeControls = true;
            GOReferences.Instance.mainCam.transform.LookAt(GOReferences.Instance.cat);
            if(GameManager.Instance.forCoroutine)
            {
                GameManager.Instance.forCoroutine = false;
                StartCoroutine(FadeOutGame());
            }
        }

    }
    IEnumerator FadeOutGame()
    {
        GameManager.Instance.newgameplus = true;
        yield return fourSec;
        panelAnim.SetTrigger("Fadethepanel");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }

}
