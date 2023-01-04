using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerGame2  : MonoBehaviour
{

    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;
    public static List<string> Game2W;

    

    void Awake()
    {
        winnerNum = NameHandler.winner;
    }

    void Start()
    {
        Game2W = new List<string>();
    }

     void Update()
    {
        StartCoroutine(Sheesh());
    }

    IEnumerator Sheesh()
    {
        if (winnerNum == 0)
        {
            winnerPlayer.text = NameHandler.playerNames[2];
            NameHandler.winner = 1;
            Game2W.Add(NameHandler.playerNames[2]);
            Debug.Log("Player 1 Wins" );
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = NameHandler.playerNames[3];
            NameHandler.winner = 2;
            Game2W.Add(NameHandler.playerNames[3]);
            Debug.Log("Player 2 Wins");
            yield return new WaitForSeconds(1f);
        }


    }

    //3 PLAYER
    public void OnClickGame3()
    {
        SceneManager.LoadScene("Game 3");
    }

      public void OnClickGame2Bracket()
    {
        SceneManager.LoadScene("3PlayerBracketDisplay");
    }
    
     public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }

    //4 PLAYERS
    public void OnClickGame2Bracket_4P()
    {
        SceneManager.LoadScene("Bracket3_4P");
    }

    //5 PLAYERS
    public void OnClickGame2Bracket_5P()
    {
        SceneManager.LoadScene("Bracket3_5P");
    }

    //6 PLAYERS
    public void OnClickGame2Bracket_6P()
    {
        SceneManager.LoadScene("Bracket3_6P");
    }
}
