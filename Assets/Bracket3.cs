using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Bracket3 : MonoBehaviour
{
    public TMP_Text Player1Name;
    public TMP_Text Player2Name;
    public TMP_Text Player3Name;
    public TMP_Text G1Winner;
    public TMP_Text G1WinnerN;
    public TMP_Text OverallWinner;

    void Start()
    {
         // Bind the playerNames list to a UI element such as a Text or Dropdown component
        Player1Name.text = NameHandler.playerNames[0];
        Player2Name.text = NameHandler.playerNames[1];
        Player3Name.text = NameHandler.playerNames[2];
        G1Winner.text = WinnerGame1.Game1W[0] + "  Winner";
        G1WinnerN.text = WinnerGame1.Game1W[0] + " - First Match Winner";
        Debug.Log("Winner Name");
    }
    //Continue to Game 2
    public void OnClickGame2()
    {
        SceneManager.LoadScene("Game 2");
    }
}
