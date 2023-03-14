using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class RingCounter : MonoBehaviour
{

    //this code makes sure the number is getting updated on the canvas on the diamond counter.

    [SerializeField] int ringCounter;
    [SerializeField] string ringNumber;
    [SerializeField] string sceneName;
    private TMP_Text diamondText;

    void Start()
    {
        diamondText = GetComponent<TMP_Text>();
        diamondText.text = ringNumber;
    }

    void Update()
    {
        if (ringNumber == "8" || ringCounter == 8)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void UpdateDiamondText(int amountToIncrease)
    {
        ringCounter -= amountToIncrease;
        diamondText.text = ringCounter.ToString();
    }

}
