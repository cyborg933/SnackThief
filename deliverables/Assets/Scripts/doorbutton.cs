using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    public float moveDistance = 50f; 
    private bool doorMoved = false;


    void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && doorMoved == false)
        {
            MoveDoor();
            doorMoved = true; 
        }
    }

    private void MoveDoor()
    {
 
        Vector3 newPosition = door.transform.position - new Vector3(0, moveDistance, 0);
        door.transform.position = newPosition; 
    }

    void Update()
    {

    }


}
