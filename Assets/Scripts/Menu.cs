using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject secondaryMenu;
    
    //This function is used for playing the tutorial
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    //Play button, Controls, and Credits all use this function
    //The credits menu will be a seperate script
    public void OnSecondaryMenu()
    {
        menu.SetActive(false);
        secondaryMenu.SetActive(true);
    }

    //Take a wild guess what this function is for
    public void OnExit()
    {
        Application.Quit();
    }

    //This function skips the tutorial scene
    public void OnSkip()
    {
        SceneManager.LoadScene(2);
    }
}
