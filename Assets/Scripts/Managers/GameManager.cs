public class GameManager : MotherSingleton<GameManager>
{
    public bool gameStart , inPhaseOne, freezeControls, inPhaseTwo;
    public int fadePoint, catDeterioration; // every 2, deteriorate
    // Start is called before the first frame update
    void Start()
    {
        fadePoint = 0;
        gameStart = true;
        inPhaseOne = false;
        inPhaseTwo = false;
        freezeControls = true;
    }
}
