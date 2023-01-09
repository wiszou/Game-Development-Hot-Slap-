using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPlayers : MonoBehaviour
{
    public TMP_Dropdown Dropdown;

    void Start()
    {
        Dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
    }

    void HandleDropdownValueChanged(int index)
    {
        int numPlayers = index + 1;
        Debug.Log("Number of players selected: " + numPlayers);
        
        if (index == 1)
        {
            SceneManager.LoadScene("2Player");


        }
        else if (index == 2)
        {
            SceneManager.LoadScene("3Player");
        }
        else if (index == 3)
        {
            SceneManager.LoadScene("4Player");
        }
         else if (index == 4)
        {
            SceneManager.LoadScene("5Player");
        }
         else if (index == 5)
        {
            SceneManager.LoadScene("6Player");
        }
      
    }
}
 