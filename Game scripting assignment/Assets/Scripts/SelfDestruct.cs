using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    #region Variables

    public bool startTimer = false;
    public float timer;
    public PlayerSettings playerSettings = null;
    public bool resetLevel = false;

    #endregion

    private void Awake()
    {
        playerSettings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
        timer = playerSettings.maxTimeAlive;
    }

    private void Start()
    {
        nullChecks();
    }

    private void nullChecks()
    {
        Debug.Assert(playerSettings != null, "There is no PlayerSettings script component attached to the GameObject tagged with 'Player'.");
    }

    private void Update()
    {
        if (startTimer)
        {
            if (timer >= 0f)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                startTimer = false;
                resetLevel = true;
            }
        }
    }
}