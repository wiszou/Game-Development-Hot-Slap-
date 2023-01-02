using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class BracketController3 : MonoBehaviour
{
    // references to the Text components
    public TMP_Text player1Text;
    public TMP_Text player2Text;
    public TMP_Text player3Text;

    void Start()
    {
        // get the input field text for each player from PlayerPrefs and display it
        string player1Name = PlayerPrefs.GetString("Player1Name");
        string player2Name = PlayerPrefs.GetString("Player2Name");
        string player3Name = PlayerPrefs.GetString("Player3Name");
        player1Text.text = player1Name;
        player2Text.text = player2Name;
        player3Text.text = player3Name;
    }

   public void Back()
   {
        SceneManager.LoadScene("3Player");
   }

}

