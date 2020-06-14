using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region

    [SerializeField] private GameObject mainMenu = null;
    [SerializeField] private GameObject questionMenu = null;

    #endregion

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetYesNoActive()
    {
        mainMenu.SetActive(false);
        questionMenu.SetActive(true);
    }

    public void SetMainMenuActive()
    {
        mainMenu.SetActive(true);
        questionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
