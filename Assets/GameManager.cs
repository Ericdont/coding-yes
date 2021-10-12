using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Player1Score;
    public int Player2Score;

    public TMP_Text Player1ScoreUI;
    public TMP_Text Player2ScoreUI;

    public void Player1Scored()
    {
        Player1Score++;
        Player1ScoreUI.text = Player1Score.ToString();
        print("Player 1 Scored! :D");
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2ScoreUI.text = Player2Score.ToString();
        print("Player 2 Scored! :D");
    }
    

   
    
}
