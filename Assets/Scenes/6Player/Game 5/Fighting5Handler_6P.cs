using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Fighting5Handler_6P : MonoBehaviour
{   
    public static List<string> Winners;
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerThreeName;
    public TextMeshProUGUI playerFourName;
    public TextMeshProUGUI playerFiveName;
    public TextMeshProUGUI playerSixName;
    public TextMeshProUGUI playerOneHPUI;
    public TextMeshProUGUI playerTwoHPUI;
 
    public int playerOneHP;
    public int playerTwoHP;

    void Awake()
    {
        playerOneName.text = WinnerGame3_6P.Game3W[0];
        playerTwoName.text = WinnerGame4_6P.Game4W[0];
        playerOneHP = NameHandler.playerHP;
        playerTwoHP = NameHandler.playerHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        Winners = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerOneHPUI.text = playerOneHP + "";
        playerTwoHPUI.text = playerTwoHP + "";
        StartCoroutine(healthChecker());
    }

    IEnumerator healthChecker()
    {   

        //Game 1
        if (playerOneHP <= 0)
        {
            NameHandler.winner = 1;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("WinnerGame5_6P");
           

        }

        if (playerTwoHP <= 0)
        {
            NameHandler.winner = 0;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("WinnerGame5_6P");
        }

        
        

    }
}
