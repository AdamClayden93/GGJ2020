using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool beginGame;
    WaitForSeconds twopointfive = new WaitForSeconds(2.5f);
    public Animator titleCatAnim;
    // Start is called before the first frame update
    void Start()
    {
        beginGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        //if (Input.GetKeyDown(KeyCode.A))
        {
            //Touch touch = Input.GetTouch(0);
            if (beginGame == false)
            {
                Debug.Log("yes");
                beginGame = true;
                StartCoroutine(StartGame());
            }
        }
    }

    IEnumerator StartGame()
    {
        titleCatAnim.SetTrigger("CatHeadTransition");
        yield return twopointfive;
        GameManager.Instance.gameStart = false;
        GameManager.Instance.inPhaseOne = true;
        GameManager.Instance.freezeControls = false;
        SceneManager.LoadScene(2);

    }
}
