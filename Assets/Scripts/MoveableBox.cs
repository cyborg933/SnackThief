using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBox : MonoBehaviour
{
    public float pushForce = 10f; 
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (rb != null)
            {

                Vector3 forceDirection = (transform.position - collision.transform.position).normalized; 
                forceDirection.y = 0; 


                rb.AddForce(forceDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}
