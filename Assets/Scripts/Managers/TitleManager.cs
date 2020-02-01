using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool beginGame;
    WaitForSeconds threeSec = new WaitForSeconds(3.0f);
    Animator titleCatAnim;
    // Start is called before the first frame update
    void Start()
    {
        beginGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (beginGame == false && touch.phase == TouchPhase.Stationary)
            {
                beginGame = true;
                StartCoroutine(StartGame());
            }
        }
    }

    IEnumerator StartGame()
    {
        titleCatAnim.SetTrigger("CatHeadTransition");
        yield return threeSec;
        SceneManager.LoadScene(2);

    }
}
