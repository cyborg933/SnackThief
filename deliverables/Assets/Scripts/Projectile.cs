using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;

    [Header("Stats")]
    [Tooltip("The speed at which the projectile will be launched.")]
    public float launchForce = 34;
    [Tooltip("The rotation speed of the projectile.")]
    public float rotationSpeed = 10;
    [Tooltip("The distance the projectile will travel before it comes to a stop.")]
    public float range = 70;

    private Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;

        // Launch the projectile forward with a force
        rb.AddForce(transform.forward * launchForce, ForceMode.VelocityChange);

        // Apply a rotational force for spinning
        rb.AddTorque(transform.right * rotationSpeed, ForceMode.VelocityChange);
    }

    void Update()
    {
        // Destroy the projectile if it has traveled beyond its range
        if (Vector3.Distance(transform.position, spawnPoint) >= range)
        {
            Destroy(gameObject);
        }
    }
}
