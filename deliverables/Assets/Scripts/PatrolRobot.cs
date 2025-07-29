using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolRobot : MonoBehaviour
{

    public float patrolSpeed = 2f;  
    public float patrolDistance = 5f; 

    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    private bool movingForward = true; 

    void Start()
    {

        startPosition = transform.position;

        targetPosition = startPosition + new Vector3(0, 0, patrolDistance);
    }

    void Update()
    {

        if (movingForward)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);
   
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingForward = false; 
                targetPosition = startPosition; 
            }
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, startPosition, patrolSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingForward = true; 
                targetPosition = startPosition + new Vector3(0, 0, patrolDistance); 
            }
        }
    }
}
