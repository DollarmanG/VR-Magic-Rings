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

    [SerializeField] private AudioSource audioSource;

    public TextMeshProUGUI text;
    public float delayTime = 2f;
    private TMP_Text diamondText;

    private bool hasReachedZero = false;

    void Start()
    {
        text.enabled = false;
        diamondText = GetComponent<TMP_Text>();
        diamondText.text = ringNumber;
    }

    void Update()
    {
        if (ringNumber == "0" || ringCounter == 0)
        {
            text.enabled = true;
            hasReachedZero = true;
            audioSource.PlayOneShot(audioSource.clip);
            Invoke("LoadNextScene", delayTime);
        }
    }

    public void UpdateDiamondText(int amountToIncrease)
    {
        ringCounter -= amountToIncrease;
        diamondText.text = ringCounter.ToString();
    }

    void LoadNextScene()
    {
        // Load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

}
