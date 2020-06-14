using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionText = null;

    // Start is called before the first frame update
    void Start()
    {
        //interactionText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        setInteractionHintActive();
    }

    private void setInteractionHintActive()
    {
        //interactionText.enabled = true;
    }
}
