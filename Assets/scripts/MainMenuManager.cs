using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//conects to all scenes connected to the menu
public class MainMenuManager : MonoBehaviour {
    public AudioSource MenuSource;
    public void GoToControls()
    {
        MenuSource.PlayOneShot(MenuSource.clip);
        SceneManager.LoadScene("Controls");

    }
    public void GoToCredits()
    {
        MenuSource.PlayOneShot(MenuSource.clip);
        SceneManager.LoadScene("Credits");
    }
    public void GoToLobby()
    {
        MenuSource.PlayOneShot(MenuSource.clip);
        SceneManager.LoadScene("Lobby");
    }
    public void QuitGame()
    {
        
    }

}
