using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public Countdown countdown; // The Countdown script to call the OnTrigger function

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            
        }
    }
}
