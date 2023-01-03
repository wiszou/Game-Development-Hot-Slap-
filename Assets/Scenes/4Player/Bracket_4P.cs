using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Bracket_4P : MonoBehaviour
{
    public TMP_Text Player1Name;
    public TMP_Text Player2Name;
    public TMP_Text Player3Name;
    public TMP_Text Player4Name;
    public TMP_Text G1Winner;
    public TMP_Text G2Winner;
    public TMP_Text G3Winner;
    public TMP_Text OverallWinner;

    void Start()
    {
         // Bind the playerNames list to a UI element such as a Text or Dropdown component
        Player1Name.text = NameHandler.playerNames[0];
        Player2Name.text = NameHandler.playerNames[1];
        Player3Name.text = NameHandler.playerNames[2];
        Player4Name.text = NameHandler.playerNames[3];
        G1Winner.text = WinnerGame1.Game1W[0];
        G2Winner.text = WinnerGame2.Game2W[0];
        G3Winner.text = WinnerGame3.Game3W[0];
        OverallWinner.text = WinnerGame3.Game3W[0];
        Debug.Log("Winner Name");
        
    }
    //FROM BRACKET 1
    public void OnClickGame1()
    {
        SceneManager.LoadScene("Game1_4P");
    }
    public void OnClickGame2()
    {
        SceneManager.LoadScene("Game2_4P");
    }
    public void OnClickGame3()
    {
        SceneManager.LoadScene("Game3_4P");
    }

}
