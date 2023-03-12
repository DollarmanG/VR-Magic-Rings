using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoisonRing : MonoBehaviour
{
    //this script is just triggering the player to to be able to collect the diamond. it also shows how much diamonds(points) should be added when taking one.

    private RingCounter diamondCounter;
    private int increaseDiamond = 1;

    void Start()
    {
        diamondCounter = FindObjectOfType<RingCounter>();
    }

    void OnTriggerEnter(Collider other)
    {
        ItemCollector playerCollector = other.GetComponent<ItemCollector>();

        if (playerCollector.gameObject.CompareTag("Poisonball"))
        {
            playerCollector.DiamondCollected();
            gameObject.SetActive(false);
            diamondCounter.UpdateDiamondText(increaseDiamond);

        }
    }
}