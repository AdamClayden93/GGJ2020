using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSequence : MonoBehaviour
{
    bool canLoadGame;
    Animator titleAnim;
    WaitForSeconds pointthree = new WaitForSeconds(0.5f);
    private void Start()
    {
        titleAnim = GetComponent<Animator>();
        canLoadGame = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (canLoadGame)
            {
                canLoadGame = false;
                titleAnim.SetTrigger("fadeoutT");
            }
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (canLoadGame)
            {
                canLoadGame = false;
                titleAnim.SetTrigger("fadeoutT");
                StartCoroutine(LoadNextScene());
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return pointthree;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}