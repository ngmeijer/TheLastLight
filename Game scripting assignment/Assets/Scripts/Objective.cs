using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Objective : MonoBehaviour
{
    #region Variables

    private GameManager gameManager = null;
    private PlayerSettings playerSettings = null;
    [SerializeField] private AudioSource audioSource = null;

    private Renderer objectiveRenderer = null;
    private BoxCollider objectiveCollider = null;

    #endregion

    private void Awake()
    {
        objectiveRenderer = GetComponent<Renderer>();
        objectiveCollider = GetComponent<BoxCollider>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerSettings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        nullChecks();
    }

    private void nullChecks()
    {
        Debug.Assert(gameManager != null, "There is no GameManager script component attached to the GameManager GameObject.");
        Debug.Assert(playerSettings != null, "There is no PlayerSettings script component attached to the GameObject tagged with 'Player'.");
        Debug.Assert(audioSource != null, "There is no AudioSource component attached to the (this) Objective GameObject.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SelfDestruct playerTimer = other.gameObject.GetComponent<SelfDestruct>();
            playerSettings.sprintSpeed += playerSettings.speedIncrease;
            playerTimer.startTimer = true;
            playerTimer.timer = playerTimer.playerSettings.maxTimeAlive;

            audioSource.Play();

            //Change to event
            gameManager.currentObjectiveCount++;

            //Because I also want to play a sound on collision, destroying isn't an option (will improve it by using coroutines but I'm short on time at the moment)
            //So simply disabling the collider and renderer for now.
            objectiveRenderer.enabled = false;
            objectiveCollider.enabled = false;
            //Destroy(gameObject);
        }
    }
}
