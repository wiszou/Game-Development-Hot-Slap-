using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerGame2 : MonoBehaviour
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
            winnerPlayer.text = WinnerGame1.Game1W[0];
            NameHandler.winner = 1;
            Game2W.Add("GameTwowinner");
            Debug.Log("Player 1 Wins" );
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = NameHandler.playerNames[2];
            NameHandler.winner = 2;
            Game2W.Add("GameTwowinner");
            Debug.Log("Player 2 Wins");
            yield return new WaitForSeconds(1f);
        }


    }

    //CONTINUE TO GAME 3
    public void OnClickGame3()
    {
        SceneManager.LoadScene("Game 3");
    }
    
}
