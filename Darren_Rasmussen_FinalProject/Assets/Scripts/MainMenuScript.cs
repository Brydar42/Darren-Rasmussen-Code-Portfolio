using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour {
    public Button play;
    public Button instructions;
    public Button quit;
    // Use this for initialization
    void Start () {
	
	}
	public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
