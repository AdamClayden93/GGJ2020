using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSequence : MonoBehaviour
{
    bool canLoadGame;
    Animator titleAnim;
    WaitForSeconds pointthree = new WaitForSeconds(0.5f);
    private readonly string fadeout = "fadeoutT";
    private void Start()
    {
        GameManager.Instance.ResetBools();
        titleAnim = GetComponent<Animator>();
        canLoadGame = true;
        if (GameManager.Instance.newgameplus)
        {
            MeowManager.Instance.SelectNewCat();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (canLoadGame)
            {
                canLoadGame = false;
                titleAnim.SetTrigger(fadeout);
                StartCoroutine(LoadNextScene());
            }
        }
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            if (canLoadGame)
            {
                canLoadGame = false;
                titleAnim.SetTrigger(fadeout);
                StartCoroutine(LoadNextScene());
            }
        }*/
    }

    IEnumerator LoadNextScene()
    {
        yield return pointthree;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}