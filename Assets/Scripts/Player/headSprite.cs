using UnityEngine;

public class headSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = MeowManager.Instance.cHead;
    }
}
