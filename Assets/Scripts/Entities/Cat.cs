using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MotherSingleton<Cat>
{
    public Transform[] fleabagLocations;
    public int fleabagIndex;
    // Start is called before the first frame update
    void Start()
    {
        FindNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindNewPosition()
    {
        fleabagIndex = Random.Range(0, 5);
    }
}
