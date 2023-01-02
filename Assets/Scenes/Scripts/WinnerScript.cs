using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerScript : MonoBehaviour
{

    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;
    public static List<string> Winners;

    void Awake()
    {
        winnerNum = NameHandler.winner;
    }

    void Start()
    {
       Winners = new List<string>();
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
            Winners.Add(NameHandler.playerNames[0]);
            Debug.Log("Player 1 Wins");
            yield return new WaitForSeconds(1f);
            
        }

        else
        {
            winnerPlayer.text = NameHandler.playerNames[1];
            NameHandler.winner = 2;
            Winners.Add(NameHandler.playerNames[1]);
            Debug.Log("Player 2 Wins");
            yield return new WaitForSeconds(1f);
        }
    }

    
}
