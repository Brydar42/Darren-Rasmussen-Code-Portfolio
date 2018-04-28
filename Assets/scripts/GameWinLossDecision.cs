using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameWinLossDecision : MonoBehaviour {
    public int Player1units=0;
    public int Player2units=0;
    public CreateUnit startTriger;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        {
            if (startTriger.readyToStart)
            {
                if (Player1units == 0 && Player2units == 0)
                {
                    SceneManager.LoadScene("Tie");//tie
                }
                //player 1 has no units
                else if (Player1units == 0)
                {
                    SceneManager.LoadScene("Player1Wins");//player1 wins
                }
                else if (Player2units == 0)
                {
                    SceneManager.LoadScene("Player2Wins");//player2 wins
                }
            }
        }
	}
}
