using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public float countdownTime = 3.0f; // The duration of the countdown in seconds
    public TextMeshProUGUI countdownText; // The TextMeshProUGUI object to display the countdown
    public GameObject triggerBox; // The trigger box object to listen for trigger events

    public string sceneName; // The name of the scene you want to load
    public float delayTime = 1.0f; // Delay time in seconds before loading the new scene
    [SerializeField] private Material triggeredMaterial;

    private Material defaultMaterial;
    private Renderer renderer;

    private bool triggerEntered = false; // Flag to check if the trigger has been entered
    private float timer = 2.0f;

    private bool countdownComplete = false;

    void Start()
    {
        countdownText.enabled = false;

        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
        // Register for trigger events
        triggerBox.GetComponent<Collider>().isTrigger = false;
        triggerBox.GetComponent<Collider>().enabled = true;
        triggerBox.GetComponent<Collider>().gameObject.AddComponent<TriggerListener>();
    }

    void Update()
    {
        if (triggerEntered && countdownComplete)
        {
            // If the trigger has been entered
            timer += Time.deltaTime; // Start the delay timer

            if (timer >= delayTime)
            {
                // If the delay time has passed
                SceneManager.LoadScene(sceneName); // Load the new scene
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            triggerEntered = true;
            renderer.material = triggeredMaterial;
            countdownText.enabled = true;
            // Start the countdown coroutine
            StartCoroutine(CountdownCoroutine());
        }
    }

    IEnumerator CountdownCoroutine()
    {
        float timeLeft = countdownTime;

        // Countdown from 3 to 1
        while (timeLeft > 0)
        {
            countdownText.text = timeLeft.ToString("0");
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }

        // Display "Start!"
        countdownText.text = "Start!";
        yield return new WaitForSeconds(1.0f);

        // Countdown complete
        countdownComplete = true;
    }
}
