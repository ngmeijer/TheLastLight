using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject objectiveBackground = null;
    [SerializeField] private TextMeshProUGUI objectiveText = null;
    [SerializeField] private TextMeshProUGUI objectiveGoal = null;

    [SerializeField] private PlayerController playerScript = null;

    List<string> objectives = new List<string>();


    //------------------------------------------------------------------//
    [Header("Objectives")]
    [SerializeField] private string entranceObjective = null;
    [SerializeField] private string newObjectiveIDKYET = null;

    // Start is called before the first frame update
    void Start()
    {
        objectiveBackground.SetActive(false);
        objectiveText.text = "";
        objectiveGoal.text = "";

        nullChecks();
    }

    // Update is called once per frame
    void Update()
    {
        //Change to method
        if (playerScript.nextObjective == 1)
        {
            objectiveBackground.SetActive(true);
            SetNewObjective(entranceObjective);
        }

        if (playerScript.nextObjective == 2)
        {
            SetNewObjective(newObjectiveIDKYET);
        }
    }

    private void SetNewObjective(string newObjective)
    {
        objectiveText.text = "Objective: ";
        objectiveGoal.text = newObjective;
    }

    private void nullChecks()
    {
        if (playerScript == null)
        {
            Debug.Log("The player's script in the GameManager cannot be found.");
        }

        if (objectiveBackground == null)
        {
            Debug.Log("The objective-trackers' background has not been inserted. Drag it into the inspector into the GameManager.");
        }

        if (objectiveText == null)
        {
            Debug.Log("The -Objective: - text has not been inserted. Drag it into the inspector into the GameManager.");
        }

        if (objectiveGoal == null)
        {
            Debug.Log("The textObject with the current objective has not been inserted. Drag it into the inspector into the GameManager.");
        }
    }
}
