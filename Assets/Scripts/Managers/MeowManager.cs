using UnityEngine;

public class MeowManager : MotherSingleton<MeowManager>
{
    // head, cats, tufts, laying cat, half cat, dead cat
    public Sprite[] catHeads;
    public Sprite[] tufts;
    public Sprite[] layingCat;
    public Sprite[] halfCats;
    public Sprite[] deadCats;
    public string CatName;
    public AudioClip[] meows;
    public AudioClip[] purrs;

    public Sprite cHead, cTuft, cLCat, chCat, cdCat;

    AudioSource myAsource;
    long purrLength;
    public int meowIndex;
    const int MAXMEOW = 4;
    // Start is called before the first frame update
    void Start()
    {
        myAsource = GetComponent<AudioSource>();
    }

    public void SelectNewCat()
    {
        meowIndex = Random.Range(0, MAXMEOW);
        cHead = catHeads[meowIndex];
        cTuft = tufts[meowIndex];
        cLCat = layingCat[meowIndex];
        chCat = halfCats[meowIndex];
        cdCat = deadCats[meowIndex];
    }

    public void PlayStartMeow()
    {
        myAsource.PlayOneShot(meows[0]);
    }

    public void PlayRandomMeow()
    {
        myAsource.PlayOneShot(meows[Random.Range(0,4)]);
    }

    public void GenerateNewPurr()
    {
        purrLength = Random.Range(0, purrs.Length);
    }

    public long ObtainPurrLength()
    {
        return purrLength * 1000;
    }

    public void PlayRandomPurr()
    {
        GenerateNewPurr();
        myAsource.PlayOneShot(purrs[(int)purrLength]);
    }
}
