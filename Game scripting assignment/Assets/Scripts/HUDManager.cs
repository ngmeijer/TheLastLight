using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PauseMenu))]
public class HUDManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject inventoryScreen = null;

    [SerializeField] private TextMeshProUGUI interactText = null;

    [SerializeField] private TextMeshProUGUI objectivesCollected = null;

    public TextMeshProUGUI timerText = null;
    private SelfDestruct playerDestroy = null;
    private GameManager gameManager = null;

    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private int maxInteractionDistance = 5;

    private bool inventoryActive;
    private bool interactTextActive = false;
    public bool SetInteractTextActive()
    {
        return interactTextActive;
    }

    #endregion

    private void Awake()
    {
        Cursor.visible = false;

        //pauseScript = GetComponent<PauseMenu>();
        //inventoryScreen.SetActive(false);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerDestroy = GameObject.Find("Player").GetComponent<SelfDestruct>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        nullChecks();
    }

    private void Update()
    {
        //handleInventoryScreen();
        checkObjectInteraction();
        ShowTimer();
    }

    private void handleInventoryScreen()
    {
        if (inventoryScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (inventoryActive)
                {
                    disableInventory();
                }
                else
                {
                    enableInventory();
                }
            }
        }
    }

    private void enableInventory()
    {
        Cursor.visible = true;
        //inventoryScreen.SetActive(true);
        //Time.timeScale = 0;
        inventoryActive = true;
    }

    private void disableInventory()
    {
        Cursor.visible = false;
        inventoryScreen.SetActive(false);
        //Time.timeScale = 1;
        inventoryActive = false;
    }

    private void checkObjectInteraction()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
        {
            if (hit.collider.gameObject.CompareTag("Interactable") && !Input.GetMouseButton(0))
            {
                interactText.enabled = true;
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    private void trackObjectiveCount()
    {
        objectivesCollected.text = "Objectives collected: " + gameManager.currentObjectiveCount;
    }

    public void ShowTimer()
    {
        if (playerDestroy.startTimer)
        {
            timerText.text = "Time left alive: " + playerDestroy.timer.ToString("f2");
            trackObjectiveCount();
        }
    }

    private void nullChecks()
    {
        
    }
}
