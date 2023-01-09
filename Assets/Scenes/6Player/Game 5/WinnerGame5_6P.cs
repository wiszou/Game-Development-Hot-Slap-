using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerGame5_6P : MonoBehaviour
{

    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;
    public static List<string> Game5W;

    

    void Awake()
    {
        winnerNum = NameHandler.winner;
    }

    void Start()
    {
        Game5W = new List<string>();
    }

     void Update()
    {
        StartCoroutine(Sheesh());
    }

    IEnumerator Sheesh()
    {
        if (winnerNum == 0)
        {
            winnerPlayer.text = WinnerGame3_6P.Game3W[0];
            NameHandler.winner = 1;
            Game5W.Add(WinnerGame3_6P.Game3W[0]);
            Debug.Log("Player 1 Wins" );
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = WinnerGame4_6P.Game4W[0];
            NameHandler.winner = 2;
            Game5W.Add(WinnerGame4_6P.Game4W[0]);
            Debug.Log("Player 2 Wins");
            yield return new WaitForSeconds(1f);
        }


    }


    //PLAY AGAIN

      public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }

    //QUIT 

     public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Exit");
        }
    

}
