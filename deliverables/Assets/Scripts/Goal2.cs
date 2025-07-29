using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.layer == 6)
        SceneManager.LoadScene("main");
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
