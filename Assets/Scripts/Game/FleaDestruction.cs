using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleaDestruction : MonoBehaviour
{

    public static event Action<List<FleaMovement>> matchingObjectClicked;

    [SerializeField]
    private float waitSeconds;

    private Vector2 queryPoint; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                queryPoint = Camera.main.ScreenToWorldPoint(touch.position);
                StartCoroutine(DestroyFlea());
            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("here");
            queryPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(DestroyFlea());
        }
    }

    private IEnumerator DestroyFlea()
    {
        yield return new WaitForSeconds(waitSeconds);

        RaycastHit2D[] hitColliders = Physics2D.CircleCastAll(queryPoint, 0.5f, new Vector2(0,0));
        List<FleaMovement> movementScripts = new List<FleaMovement>(); 
        for(int i = 0; i < hitColliders.Length; i++)
        {
            FleaMovement movement = hitColliders[i].collider.GetComponent<FleaMovement>();
            if(movement != null)
            {
                movementScripts.Add(movement);
            }
        }
        if(hitColliders.Length > 0)
        {
            matchingObjectClicked.Invoke(movementScripts);
        }


    }
}
