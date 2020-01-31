using UnityEngine;

public class MasterLoader : MonoBehaviour
{
    #region debugging only
    const int _iLEVEL_TO_LOAD = 1; // Change this to the scene you want to test
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_iLEVEL_TO_LOAD);
    }
}
