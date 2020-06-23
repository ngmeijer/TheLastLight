using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTutorialReqs : MonoBehaviour
{
    public bool hasHit = false;
    public bool setTextActive = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasHit)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                setTextActive = true;
                hasHit = true;
            }
        }
    }
}
