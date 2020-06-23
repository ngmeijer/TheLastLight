using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    #region Variables

    private GameManager gameManager = null;
    private PlayerSettings playerSettings = null;

    #endregion

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerSettings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
    }

    private void Start()
    {
        nullChecks();
    }

    private void nullChecks()
    {
        Debug.Assert(gameManager != null, "There is no GameManager script component attached to the GameManager GameObject.");
        Debug.Assert(playerSettings != null, "There is no PlayerSettings script component attached to the GameObject tagged with 'Player'.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SelfDestruct playerTimer = other.gameObject.GetComponent<SelfDestruct>();
            playerSettings.sprintSpeed += playerSettings.speedIncrease;
            playerTimer.startTimer = true;
            playerTimer.timer = playerTimer.playerSettings.maxTimeAlive;

            //Change to event
            gameManager.currentObjectiveCount++;
            Destroy(gameObject);
        }
    }
}
