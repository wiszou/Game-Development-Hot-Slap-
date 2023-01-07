using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FightingHandler_2P : MonoBehaviour
{   
    public static List<string> Winners;
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerOneHPUI;
    public TextMeshProUGUI playerTwoHPUI;
    private GameManager_2P gameManager;
    public int energyGainPerHit = 10; // Change 10 to the desired energy gain value
    public Slider healthBarSliderP1;
    public Slider healthBarSliderP2;
 
    public int playerOneHP;
    public int playerTwoHP;

    void Awake()
    {
        playerOneName.text = NameHandler.playerNames[0];
        playerTwoName.text = NameHandler.playerNames[1];
        playerOneHP = NameHandler.playerHP;
        playerTwoHP = NameHandler.playerHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        Winners = new List<string>();
        gameManager = GetComponent<GameManager_2P>();
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
    public void TakeDamage(int damage)
{
    // Decrease the player's health by the specified amount
    playerTwoHP -= damage;

    // Add energy to player one's energy
    gameManager.playerOneEnergy += energyGainPerHit;

    // Print a debug log message
    Debug.Log("Energy gained: " + energyGainPerHit);

    // Update the UI text element to show the updated health value
    playerTwoHPUI.text = playerTwoHP + "";
}


    IEnumerator healthChecker()
    {   

        //GAME 1
        if (playerOneHP <= 0)
        {
            NameHandler.winner = 1;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("OverallWinner");
           

        }

        if (playerTwoHP <= 0)
        {
            NameHandler.winner = 0;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("OverallWinner");
        }

    }
}
