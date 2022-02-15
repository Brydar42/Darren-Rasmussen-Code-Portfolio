using UnityEngine;
using System.Collections;

public class SpashSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GoToGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("testScene");
    }
    public void GoToInstuctionScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("instuctions");
    }
}
