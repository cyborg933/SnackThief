using UnityEngine;

public class Cup : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (rb != null)
            {
            Vector3 collisionNormal = collision.contacts[0].normal;

            // normal reverse
            Vector3 forceDirection = -collisionNormal; 
            forceDirection.y = 0; //no y offset


            rb.AddForce(forceDirection.normalized * 7f, ForceMode.Impulse);
            }
        }
    }
}
