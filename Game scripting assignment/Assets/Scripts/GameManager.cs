using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables

    private SelfDestruct playerReset = null;
    public int currentObjectiveCount = 0;
    public int maxObjectiveCount = 7;

    #endregion

    private void Awake()
    {
        playerReset = GameObject.FindGameObjectWithTag("Player").GetComponent<SelfDestruct>();
    }

    private void Start()
    {
        nullChecks();
    }

    private void Update()
    {
        trackLevelReset();
        trackObjectiveCount();
    }

    private void trackLevelReset()
    {
        if (playerReset.resetLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerReset.resetLevel = false;
        }
    }

    private void trackObjectiveCount()
    {
        if(currentObjectiveCount >= maxObjectiveCount)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void nullChecks()
    {
        Debug.Assert(playerReset != null, "The SelfDestruct script on the Player GameObject could not be found.");
    }
}
