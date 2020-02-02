using UnityEngine;

public class Cat : MotherSingleton<Cat>
{
    public Transform[] fleabagLocations;
    public int fleabagIndex;
    Vector3 catPos;
    public ParticleSystem hearts;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = MeowManager.Instance.cLCat;
        FindNewPosition();
    }

    private void Update()
    {
        catPos = GOReferences.Instance.mainCam.WorldToViewportPoint(transform.position);
        bool onScreen = catPos.x > 0 && catPos.x < 1 && catPos.y > 0 && catPos.y < 1;
        print(onScreen);
        if(!onScreen && Time.frameCount % 250 == 0)
        {
            MeowManager.Instance.PlayRandomMeow();
        }
        if(onScreen && Time.frameCount % 250 == 0)
        {
            hearts.Play();
            //play hearts animation
        }
    }

    void FindNewPosition()
    {
        fleabagIndex = Random.Range(0, 5);
    }
}
