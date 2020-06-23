using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PauseMenu))]
[RequireComponent(typeof(Animator))]
public class HUDManager : MonoBehaviour
{
    #region Variables

    private SelfDestruct playerDestroy = null;
    private GameManager gameManager = null;
    private PauseMenu pauseScript = null;
    private CheckTutorialReqs tutColliderCheck = null;

    private Animator canvasAnim = null;

    [SerializeField] private GameObject inventoryScreen = null;
    [SerializeField] private TextMeshProUGUI interactText = null;
    [SerializeField] private TextMeshProUGUI objectivesCollected = null;
    public TextMeshProUGUI timerText = null;

    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private int maxInteractionDistance = 5;

    private bool inventoryActive;

    #endregion

    private void Awake()
    {
        pauseScript = GetComponent<PauseMenu>();
        canvasAnim = GetComponentInParent<Animator>();

        playerDestroy = GameObject.Find("Player").GetComponent<SelfDestruct>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tutColliderCheck = GameObject.FindGameObjectWithTag("InteractionHitbox").GetComponent<CheckTutorialReqs>();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        nullChecks();
    }

    private void nullChecks()
    {
        Debug.Assert(pauseScript != null, "The PauseMenu script is not attached to the HUD GameObject.");
        Debug.Assert(canvasAnim != null, "There is no Animator component attached to the Canvas GameObject.");
        Debug.Assert(playerDestroy != null, "There is no SelfDestruct script component attached to the Player GameObject.");
        Debug.Assert(gameManager != null, "There is no GameManager script component attached to the GameManager GameObject.");
        Debug.Assert(tutColliderCheck != null, "There is no CheckTutorialReqs script component attached to the ObjectiveHolder GameObject, or it is not tagged with 'InteractionHitbox'.");
    }

    private void Update()
    {
        checkObjectInteraction();
        ShowTimer();
        checkTutorialCol();
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

    private void checkTutorialCol()
    {
        if (tutColliderCheck.setTextActive) 
        { 
            canvasAnim.SetTrigger("hitObjective");
        }
        else return;
    }

}
