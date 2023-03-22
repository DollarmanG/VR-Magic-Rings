using UnityEngine;
using UnityEngine.XR;

public class PersistentVRMenu : MonoBehaviour
{
    public static PersistentVRMenu instance;

    public GameObject menuPrefab;
    public XRNode inputSource = XRNode.RightHand;
    public float menuDistance = 0.5f;

    private GameObject menuInstance;
    private bool menuActive = false;
    private Vector3 initialPosition;
    private Vector3 menuPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        initialPosition = transform.position;
        menuPosition = Camera.main.transform.position + Camera.main.transform.forward * menuDistance;
        CreateMenu();
    }

    void Update()
    {
        InputDevice inputDevice = InputDevices.GetDeviceAtXRNode(inputSource);
        bool triggerButton;
        if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButton) && triggerButton)
        {
            if (!menuActive)
            {
                ShowMenu();
                Time.timeScale = 0f;
            }
        }
        else
        {
            if (menuActive)
            {
                HideMenu();
                Time.timeScale = 1f;
            }
        }
    }

    void CreateMenu()
    {
        if (menuPrefab != null)
        {
            menuInstance = Instantiate(menuPrefab, menuPosition, Quaternion.identity);
            menuInstance.transform.SetParent(transform);
            menuInstance.SetActive(false);
        }
    }

    void ShowMenu()
    {
        if (menuInstance != null)
        {
            transform.position = menuPosition;
            transform.LookAt(Camera.main.transform);
            menuActive = true;
            menuInstance.SetActive(true);
        }
    }

    void HideMenu()
    {
        if (menuInstance != null)
        {
            transform.position = initialPosition;
            menuActive = false;
            menuInstance.SetActive(false);
        }
    }
}