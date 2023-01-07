using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Fighting4Handler_5P : MonoBehaviour
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
    public Slider healthBarSliderP1;
    public Slider healthBarSliderP2;
 
    public int playerOneHP;
    public int playerTwoHP;

    void Awake()
    {
        playerOneName.text = WinnerGame3_5P.Game3W[0];
        playerTwoName.text = WinnerGame2.Game2W[0];
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

        // Update the health bar to reflect the current health of the player
        healthBarSliderP1.value = playerOneHP / (float)NameHandler.playerHP;
        healthBarSliderP2.value = playerTwoHP / (float)NameHandler.playerHP;
        StartCoroutine(healthChecker());
    }

    IEnumerator healthChecker()
    {   

        //Game 1
        if (playerOneHP <= 0)
        {
            NameHandler.winner = 1;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("WinnerGame4_5P");
           

        }

        if (playerTwoHP <= 0)
        {
            NameHandler.winner = 0;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("WinnerGame4_5P");
        }

        
        

    }
}
