using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PauseMenu))]
public class HUDManager : MonoBehaviour
{
    #region Variables

    private PauseMenu pauseScript = null;

    [SerializeField] private GameObject inventoryScreen = null;

    [SerializeField] private TextMeshProUGUI interactText = null;

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
        nullChecks();
    }

    private void Update()
    {
        Debug.Log(Cursor.lockState);
        //handleMouseVisib();
        //handleInventoryScreen();
        //checkObjectInteraction();
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

    private void handleMouseVisib()
    {
        //if (!inventoryActive && !pauseScript.PauseMenuActive)
        //{
        //}
        //else
        //{
        //    //Cursor.lockState = CursorLockMode.Confined;
        //}
    }

    private void enableInventory()
    {
        Cursor.visible = true;
        inventoryScreen.SetActive(true);
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

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Interactable") && !Input.GetMouseButton(0))
            {
                interactText.enabled = true;
            }
            else
            {
                interactText.enabled = false;
            }
        }
    }

    private void nullChecks()
    {
        if (inventoryScreen == null)
        {
            Debug.Log("The inventory-screen Gameobject cannot be found. Insert it from the hierarchy into the inspector.");
        }
    }
}
