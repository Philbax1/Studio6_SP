using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject mainMenuGroup;
    public GameObject controlsGroup;
    public GameObject creditsGroup;

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showOptions()
    {
        mainMenuGroup.SetActive(false);
        controlsGroup.SetActive(true);
        creditsGroup.SetActive(false);
    }
    public void showCredits()
    {
        mainMenuGroup.SetActive(false);
        controlsGroup.SetActive(false);
        creditsGroup.SetActive(true);
    }
    public void backToMain()
    {
        mainMenuGroup.SetActive(true);
        controlsGroup.SetActive(false);
        creditsGroup.SetActive(false);
    }
}
