using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleaMovement : MonoBehaviour
{
    [SerializeField]
    private float wanderRadius;
    [SerializeField]
    private float speed = 4f;
   
    [SerializeField]
    private Vector2 currentGoal;

    private float step;

    void Awake()
    {
        FleaDestruction.matchingObjectClicked += HandleFleaDestruction;
    }
    void OnDisable()
    {
        FleaDestruction.matchingObjectClicked -= HandleFleaDestruction;
    }
    void Start()
    {
        step = speed * Time.deltaTime;
        currentGoal = (Vector2)transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Wander();   
    }

    private void Wander()
    {
        //if less than 1 unit away from goal
        if(Vector2.Distance(transform.position, currentGoal) < 1f)
        {
            //get new goal
            currentGoal = (Vector2)transform.position + (Random.insideUnitCircle * wanderRadius);
            //while goal is outside of the allowed radius, find a new one until it is inside the allowed radius
           while(currentGoal.x < -SpawningManager.Instance.spawningArea.x || 
           currentGoal.x > SpawningManager.Instance.spawningArea.x || 
           currentGoal.y < -SpawningManager.Instance.spawningArea.y||
           currentGoal.y > SpawningManager.Instance.spawningArea.y)
           {
               currentGoal = (Vector2)transform.position + (Random.insideUnitCircle * wanderRadius);
           }
        }
        transform.position = Vector2.MoveTowards(transform.position, currentGoal, step);
    }

    private void HandleFleaDestruction(List<FleaMovement> fleaMovements)
    {
        if(fleaMovements.Contains(this))
        {
            Debug.Log("Flea destruction");
            Destroy(this.gameObject);
        }
    }
}
