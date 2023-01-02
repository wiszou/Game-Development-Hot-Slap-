using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    public TMP_InputField player3Input;
    public TMP_InputField player4Input;
    public TMP_InputField player5Input;
    public TMP_InputField player6Input;
    // Add additional input fields as needed

    public NameHandler nameHandler;

    void Start()
    {
        nameHandler = GetComponent<NameHandler>();
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Game");
    }
}
