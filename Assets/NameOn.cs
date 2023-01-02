using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameOn : MonoBehaviour
{
    public TMP_Text Player1Name;
    public TMP_Text Player2Name;
    public TMP_Text Player3Name;
    public TMP_Text Player4Name;
    public TMP_Text Player5Name;
    public TMP_Text Player6Name;

    

    void Start()
    {
        // Bind the playerNames list to a UI element such as a Text or Dropdown component
        Player1Name.text = NameHandler.playerNames[0];
        Player2Name.text = NameHandler.playerNames[1];
        Player3Name.text = NameHandler.playerNames[2];
        Player4Name.text = NameHandler.playerNames[3];
        Player5Name.text = NameHandler.playerNames[4];
        Player6Name.text = NameHandler.playerNames[5];
    }
}
