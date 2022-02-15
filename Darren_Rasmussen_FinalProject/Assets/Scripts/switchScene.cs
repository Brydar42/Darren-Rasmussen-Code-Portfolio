using UnityEngine;
using System.Collections;

public class switchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GoToMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
