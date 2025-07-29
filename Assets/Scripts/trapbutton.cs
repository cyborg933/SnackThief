using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trapbutton : MonoBehaviour
{ 
    
    public Nailboard[] nailBoards;

    private void OnTriggerEnter(Collider other)
    {
         foreach (Nailboard nailBoard in nailBoards)
            {
                if (nailBoard != null)
                {
                    nailBoard.TriggerMovement();
                }
            }
    }
}
