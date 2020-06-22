using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private GameManager gameManager = null;
    private PlayerSettings playerSettings = null;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerSettings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
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
