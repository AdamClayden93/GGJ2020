using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleaMovement : MonoBehaviour
{
    [SerializeField]
    private float wanderRadius;
    [SerializeField]
    private float speed = 4f;
    private Vector2 currentGoal;

    private float step;

    void Start()
    {
        step = speed * Time.deltaTime;
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
            currentGoal = Random.insideUnitCircle * wanderRadius;
           // if(currentGoal.)
        }
        transform.position = Vector2.MoveTowards(transform.position, currentGoal, step);
    }
}
