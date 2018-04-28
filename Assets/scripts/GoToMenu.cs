using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//returns the player to the main menu
public class GoToMenu : MonoBehaviour {
    public AudioSource MenuSource;
    public void GoToBackMenu()
    {
        MenuSource.PlayOneShot(MenuSource.clip);
        SceneManager.LoadScene("MainMenu");
    }
}
