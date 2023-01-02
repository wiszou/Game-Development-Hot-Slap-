using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WinnerGame1 : MonoBehaviour
{

    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;
    public static List<string> Game1W;

    void Awake()
    {
        winnerNum = NameHandler.winner;
    }

    void Start()
    {
       Game1W = new List<string>();
    }

     void Update()
    {
        StartCoroutine(Sheesh());
    }

    IEnumerator Sheesh()
    {
        if (winnerNum == 0)
        {
            winnerPlayer.text = NameHandler.playerNames[0];
            NameHandler.winner = 1;
            Game1W.Add(NameHandler.playerNames[0]);
            Debug.Log("Player 1 added to Game1W" );
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = NameHandler.playerNames[1];
            NameHandler.winner = 2;
            Game1W.Add(NameHandler.playerNames[1]);
            Debug.Log("Player 2 added to Game1W");
            yield return new WaitForSeconds(1f);
        }


    }

    //CONTINUE TO GAME 2
    public void OnClickGame2()
    {
        SceneManager.LoadScene("Game 1");
    }

     public void OnClickGame1Bracket()
    {
        SceneManager.LoadScene("3PlayerBracketDisplay");
    }
    
}
