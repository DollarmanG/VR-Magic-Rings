using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RingCounter : MonoBehaviour
{

    //this code makes sure the number is getting updated on the canvas on the diamond counter.

    private int counter;
    private TMP_Text diamondText;

    void Start()
    {
        diamondText = GetComponent<TMP_Text>();
        diamondText.text = "0";
    }

    public void UpdateDiamondText(int amountToIncrease)
    {
        counter += amountToIncrease;
        diamondText.text = counter.ToString();
    }

}
