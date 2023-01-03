using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Bracket_3P : MonoBehaviour
{
    public TMP_Text Player1Name;
    public TMP_Text Player2Name;
    public TMP_Text Player3Name;
    public TMP_Text G1Winner;
    public TMP_Text OverallWinner;

    void Start()
    {
         // Bind the playerNames list to a UI element such as a Text or Dropdown component
        Player1Name.text = NameHandler.playerNames[0];
        Player2Name.text = NameHandler.playerNames[1];
        Player3Name.text = NameHandler.playerNames[2];
        G1Winner.text = WinnerGame1.Game1W[0];
        OverallWinner.text = WinnerGame2.Game2W[0];
        Debug.Log("Winner Name");
        
    }
    //FROM BRACKET 1
    public void OnClickGame1()
    {
        SceneManager.LoadScene("Game 1");
    }
    public void OnClickGame2()
    {
        SceneManager.LoadScene("Game 2");
    }
}
