using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    //the codes check the current number of diamonds and then adds value to it when taking another.
    //the script is connected to another script called Diamond where the trigger of the player to the diamond happends.
    public int NumberofDiamonds { get; private set; }

    public void DiamondCollected()
    {
        NumberofDiamonds--;
    }
}
