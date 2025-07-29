using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.layer == 6) 
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
            player.Die(); 
    }
}
    void Update()
    {
        
    }
}
