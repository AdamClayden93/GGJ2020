public class GameManager : MotherSingleton<GameManager>
{
    public bool gameStart , inPhaseOne, freezeControls, inPhaseTwo, forCoroutine, newgameplus;
    public int fadePoint, catDeterioration; // every 2, deteriorate
    // Start is called before the first frame update
    void Start()
    {
        newgameplus = false;
        forCoroutine = true;
        fadePoint = 0;
        gameStart = true;
        inPhaseOne = false;
        inPhaseTwo = false;
        freezeControls = true;
    }

    public void ResetBools()
    {
        forCoroutine = true;
        fadePoint = 0;
        gameStart = true;
        inPhaseOne = false;
        inPhaseTwo = false;
        freezeControls = true;
        Stroking.Instance.lerpCamera = false;
    }
}
