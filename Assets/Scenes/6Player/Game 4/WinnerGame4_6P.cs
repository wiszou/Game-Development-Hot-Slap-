using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerGame4_6P : MonoBehaviour
{

    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;
    public static List<string> Game4W;

    

    void Awake()
    {
        winnerNum = NameHandler.winner;
    }

    void Start()
    {
        Game4W = new List<string>();
    }

     void Update()
    {
        StartCoroutine(Sheesh());
    }

    IEnumerator Sheesh()
    {
        if (winnerNum == 0)
        {
            winnerPlayer.text = WinnerGame2.Game2W[0];
            NameHandler.winner = 1;
            Game4W.Add(WinnerGame2.Game2W[0]);
            Debug.Log("Player 1 Wins" );
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = NameHandler.playerNames[5];
            NameHandler.winner = 2;
            Game4W.Add(NameHandler.playerNames[5]);
            Debug.Log("Player 2 Wins");
            yield return new WaitForSeconds(1f);
        }


    }


    //CONTINUE TO GAME 5

      public void OnClickGame4Bracket()
    {
        SceneManager.LoadScene("Bracket5_6P");
    }

}
