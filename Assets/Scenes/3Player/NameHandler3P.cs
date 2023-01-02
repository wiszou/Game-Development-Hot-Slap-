using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameHandler3P : MonoBehaviour
{
    // references to the InputField components
    public TMP_InputField player1InputField;
    public TMP_InputField player2InputField;
    public TMP_InputField player3InputField;

    void Start()
    {
        // get the input field text for each player and save it to PlayerPrefs
        string player1Name = player1InputField.text;
        string player2Name = player2InputField.text;
        string player3Name = player3InputField.text;
        PlayerPrefs.SetString("Player1Name", player1Name);
        PlayerPrefs.SetString("Player2Name", player2Name);
        PlayerPrefs.SetString("Player3Name", player3Name);
    }

    public void Play()
    {
        SceneManager.LoadScene("3PlayerBracketDisplay");
    }
}