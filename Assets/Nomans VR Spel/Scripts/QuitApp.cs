using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    [SerializeField] private Material triggeredMaterial;

    private Material defaultMaterial;
    private Renderer renderer;

    public float delayTime = 1.0f;
    private bool triggerEntered = false;

    private float timer = 2.0f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the specified tag
        if (other.CompareTag("Fireball"))
        {
            renderer.material = triggeredMaterial;
        }
    }

    void Update()
    {
        if (triggerEntered)
        {
            // If the trigger has been entered
            timer += Time.deltaTime; // Start the delay timer

            if (timer >= delayTime)
            {
                Debug.Log("Quits the App.");
                // If the delay time has passed
                Application.Quit();
            }
        }
    }
}
