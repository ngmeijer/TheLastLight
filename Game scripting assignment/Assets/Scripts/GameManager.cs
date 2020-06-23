using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SelfDestruct playerReset = null;

    public int currentObjectiveCount = 0;
    public int maxObjectiveCount = 7;

    void Start()
    {
        playerReset = GameObject.FindGameObjectWithTag("Player").GetComponent<SelfDestruct>();
    }

    void Update()
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
}
