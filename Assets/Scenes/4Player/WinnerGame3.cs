using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerGame3 : MonoBehaviour
{

    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;
    public static List<string> Game3W;

    

    void Awake()
    {
        winnerNum = NameHandler.winner;
    }

    void Start()
    {
        Game3W = new List<string>();
    }

     void Update()
    {
        StartCoroutine(Sheesh());
    }

    IEnumerator Sheesh()
    {
        if (winnerNum == 0)
        {
            winnerPlayer.text = WinnerGame1.Game1W[0];
            NameHandler.winner = 1;
            Game3W.Add("GameThreeWinner");
            Debug.Log("Player 1 Wins" );
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = WinnerGame2.Game2W[0];
            NameHandler.winner = 2;
            Game3W.Add("GameThreewinner");
            Debug.Log("Player 2 Wins");
            yield return new WaitForSeconds(1f);
        }


    }

    //CONTINUE TO GAME 3
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

    //CONTINUE TO GAME 4

      public void OnClickGame3Bracket()
    {
        SceneManager.LoadScene("Bracket4_5P");
    }

}
