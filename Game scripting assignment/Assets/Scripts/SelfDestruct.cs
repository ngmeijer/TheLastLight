using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool startTimer = false;
    public float timer;
    public PlayerSettings playerSettings = null;
    public bool resetLevel = false;

    private void Start()
    {
        playerSettings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
        timer = playerSettings.maxTimeAlive;
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