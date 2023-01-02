using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TournamentHandler : MonoBehaviour
{
    public List<int> players; // list of players and their health points
    public List<int> winners; // list of players who have won their matches
    public int currentRound = 1; // current round of the tournament
    public TMP_Text winnerText; // UI text element to display the overall winner
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerOneHPUI;
    public TextMeshProUGUI playerTwoHPUI;
    public int playerOneHP;
    public int playerTwoHP;


    void Awake()
    {
        playerOneName.text = NameHandler.playerNames[0];
        playerTwoName.text = NameHandler.playerNames[1];
        playerOneHP = NameHandler.playerHP;
        playerTwoHP = NameHandler.playerHP;
    }

    void Start()
    {
        // Initialize the list of players with the starting health points for each player
        players = new List<int>();
        for (int i = 0; i < NameHandler.playerNames.Count; i++)
        {
            players.Add(NameHandler.playerHP);
        }
    }

    void Update()
    {
        // Check if the current round is complete
        int player1 = players[currentRound - 1];
        int player2 = players[currentRound];
        if (player1 <= 0 || player2 <= 0)
        {
            // Determine the winner of the current round and add them to the list of winners
            if (player1 <= 0)
            {
                // player 2 wins the match
                winners.Add(player2);
            }
            else if (player2 <= 0)
            {
                // player 1 wins the match
                winners.Add(player1);
            }

            // Remove the losing player from the list of players
            players.Remove(Mathf.Min(player1, player2));

            // Advance to the next round
            currentRound++;
        }

        // Check if the tournament is complete
        if (players.Count == 1)
        {
            // The remaining player is the overall winner
            int winner = players[0];
            winnerText.text = "WINNER: " + NameHandler.playerNames[winner];
        }
    }
}