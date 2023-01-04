using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager_2P : MonoBehaviour
{
    
    public Animator animatorPlayerAttk; // The playerattack's animator component
    public Animator animatorPlayerDodge; // The attackerdodge's animator component
    public Animator animatorEnemyAttk; // The enemyattack's animator component
    public Animator animatorEnemyDodge; // The enemydodge's animator component
    public Animator animatorPlayerUlti; // The playerulti's animator component
    public Animator animatorEnemyUlti; // The enemyulti's animator component
    public float ultiDuration = 1f; // The ultimate attack animation lasts for 1.5 seconds
    public int ultiPower = 30; // The amount of damage the player does with the ultimate attack
    public float dodgeDuration = 0.9f; // Dodge lasts for 0.5 seconds
    public float attackDuration = 0.3f; // The attack animation lasts for 0.5 seconds
    public int attackPower = 10; // The amount of damage the attacker does with each attack
    public GameObject player1; // The player being attack
    public GameObject enemy1; // The enemy being attack
    public int playerOneEnergy = 0; // Player 1's starting energy
    public int playerTwoEnergy = 0; // Player 2's starting energy
    public int energyGainPerHit = 10; // Change 10 to the desired energy gain value
    public int energyCostPerUlti = 50; // The amount of energy required to use the ultimate attack
    public bool ultimateAttackEnabled = false; // Flag to track if the ultimate attack is enabled for the player
    public FightingHandler_2P fightingHandler_2P; // Add a reference to the fightingHandler_2P script

    // Flag to track whose turn it is
    private bool isPlayer1Turn = true;
    private bool enemyDodged = false;
    private bool dodgeButtonDisabled = false;
    private float dodgeButtonTimer = 0f;
    public float deathAnimationDuration = 0.3f;

    void Update()
    {
        // Check if it's player 1's turn
        if (isPlayer1Turn)
        {
            // Check if player 1 has made their move
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isPlayer1Turn = false;
                StartCoroutine(WaitForAttackQ());
            }
        }
        // Otherwise, it's player 2's turn
        else
        {
            // Check if player 2 has made their move
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                isPlayer1Turn = true;
                StartCoroutine(WaitForAttack1());
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPlayer1Turn = false;
            StartCoroutine(WaitForUltiE());
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            isPlayer1Turn = false;
            StartCoroutine(WaitForUlti3());
        }

        if (Input.GetKey(KeyCode.Keypad2) && !dodgeButtonDisabled)
            {
                // Disable the dodge button to prevent spamming
            dodgeButtonDisabled = true;
                // Set the flag to indicate that the enemy has dodged
                enemyDodged = true;
                // Start the dodge animation and wait for it to finish
                animatorEnemyDodge.SetTrigger("Dodge");
                StartCoroutine(WaitForDodge2());
            }
    if (Input.GetKey(KeyCode.W) && !dodgeButtonDisabled)
    {
        // Disable the dodge button to prevent spamming
            dodgeButtonDisabled = true;
        // Set the flag to indicate that the enemy has dodged
            enemyDodged = true;
            // Start the dodge animation and wait for it to finish
            animatorPlayerDodge.SetTrigger("Dodge");
            StartCoroutine(WaitForDodgeW());
    }
    if (dodgeButtonDisabled)
    {
        dodgeButtonTimer += Time.deltaTime;
    if (dodgeButtonTimer >= dodgeDuration)
        {
            dodgeButtonDisabled = false;
            dodgeButtonTimer = 0f;
        }
    }
    // Check if player 1's hit points have reached 0
    if (fightingHandler_2P.playerOneHP <= 0)
    {
        // Trigger the death sequence for player 1
        StartCoroutine(DeathSequence1(player1));
    }
    // Check if player 2's hit points have reached 0
    if (fightingHandler_2P.playerTwoHP <= 0)
    {
        // Trigger the death sequence for player 2
        StartCoroutine(DeathSequence2(enemy1));
    }
}
    // Attack the enemy
    public void AttackEnemy(GameObject other)
    {
        // Decrease the enemy's hit points
        fightingHandler_2P.playerTwoHP -= attackPower;
        // Increase the player's energy
        playerOneEnergy += energyGainPerHit;
        // Check if the player's energy has reached the required amount for the ultimate attack
    if (playerOneEnergy >= energyCostPerUlti)
        {
        // Attack the enemy with the ultimate attack
        AttackEnemyUlti(enemy1);
        // Reset the player's energy
        playerOneEnergy = 0;
        // Enable the ultimate attack
        ultimateAttackEnabled = true;
        }
        // Start the attack animation and wait for it to finish
        animatorPlayerAttk.SetBool("Attack", true);
    }
     // Attack the player
    public void AttackPlayer(GameObject other)
    {
        // Decrease the player's hit points
        fightingHandler_2P.playerOneHP -= attackPower;
        // Increase the enemy's energy
        playerTwoEnergy += energyGainPerHit;
        // Check if the player's energy has reached the required amount for the ultimate attack
    if (playerTwoEnergy >= energyCostPerUlti)
        {
        // Attack the player with the ultimate attack
        AttackPlayerUlti(player1);
        // Reset the player's energy
        playerTwoEnergy = 0;
        ultimateAttackEnabled = true;
        }
        // Start the attack animation and wait for it to finish
        animatorEnemyAttk.SetBool("Attack", true);
    }
    // Attack the enemy with the ultimate attack
    public void AttackEnemyUlti(GameObject other)
    {
        // Check if the player has enough energy to use the ultimate attack
        if (playerOneEnergy >= energyCostPerUlti)
        {
        // Decrease the enemy's hit points
        fightingHandler_2P.playerTwoHP -= ultiPower;
        // Decrease the player's energy
        playerOneEnergy -= energyCostPerUlti;
        // Start the ultimate attack animation and wait for it to finish
        animatorPlayerUlti.SetBool("Attack", true);
        }
    }
    // Attack the player with the ultimate attack
    public void AttackPlayerUlti(GameObject other)
    {
        // Check if the player has enough energy to use the ultimate attack
        if (playerTwoEnergy >= energyCostPerUlti)
        {
        // Decrease the enemy's hit points
        fightingHandler_2P.playerOneHP -= ultiPower;
        // Decrease the player's energy
        playerTwoEnergy -= energyCostPerUlti;
        // Start the ultimate attack animation and wait for it to finish
        animatorEnemyUlti.SetBool("Attack", true);
        }
    }

    private IEnumerator WaitForUltiE()
    {
    // Check if the player has enough energy to use the ultimate attack
    if (playerOneEnergy >= energyCostPerUlti && ultimateAttackEnabled)
    {
        // Subtract the energy cost from the player's energy
        playerOneEnergy -= energyCostPerUlti;

        // Trigger the ultimate attack animation
        animatorPlayerUlti.SetTrigger("Ulti");

        // Wait for the ultimate attack animation to finish
        yield return new WaitForSeconds(ultiDuration);

        // Check if the enemy dodged
        if (!enemyDodged)
        {
            // Apply the ultimate attack damage to the enemy
            enemy1.GetComponent<FightingHandler_2P>().TakeDamage(ultiPower);
        }

        // Reset the enemy dodged flag
        enemyDodged = false;
    }
    else
    {
        // Notify the player that they don't have enough energy to use the ultimate attack
        Debug.Log("Not enough energy to use ultimate attack");
    }
    // Allow the other player to make a move
    isPlayer1Turn = true;
    }
    private IEnumerator WaitForUlti3()
    {
    // Attack the player with the ultimate attack
    AttackPlayerUlti(player1);
    // Wait for the ultimate attack animation to finish
    yield return new WaitForSeconds(ultiDuration);
    // Allow the other player to make a move
    isPlayer1Turn = true;
    }
    
    IEnumerator DeathSequence1(GameObject player1)
        {
        // Wait for the death animation to finish
        yield return new WaitForSeconds(deathAnimationDuration);

        // Destroy the character game object
        Destroy(player1);

        // Transition to the next scene to reveal the winner
        SceneManager.LoadScene("WinnerScene");
        }

    IEnumerator DeathSequence2(GameObject enemy1)
        {
        // Wait for the death animation to finish
        yield return new WaitForSeconds(deathAnimationDuration);
        // Destroy the character game object
        Destroy(enemy1);
        // Transition to the next scene to reveal the winner
        SceneManager.LoadScene("WinnerScene");
        }

    IEnumerator WaitForAttackQ()
        {
        animatorPlayerAttk.SetTrigger("Attack");
        // Wait for the remaining attack duration
        yield return new WaitForSeconds(attackDuration);
        // If the enemy has not pressed the dodge button during the attack animation, decrease their hit points
        if (!enemyDodged)
        {
            fightingHandler_2P.playerTwoHP -= attackPower;
        }
        // Reset the enemyDodged flag for the next attack
        enemyDodged = false;
        // Turn off the attack animation
        animatorPlayerAttk.SetBool("Attack", false);
        }

     IEnumerator WaitForAttack1()
        {
        animatorEnemyAttk.SetTrigger("Attack");
        // Wait for the remaining attack duration
        yield return new WaitForSeconds(attackDuration);
        // If the enemy has not pressed the dodge button during the attack animation, decrease their hit points
        if (!enemyDodged)
        {
            fightingHandler_2P.playerOneHP -= attackPower;
        }
        // Reset the enemyDodged flag for the next attack
        enemyDodged = false;
         // Turn off the attack animation
        animatorEnemyAttk.SetBool("Attack", false);
        }

    IEnumerator WaitForDodgeW()
        {
            dodgeButtonDisabled = true;
            // Wait for the specified duration
            yield return new WaitForSeconds(dodgeDuration);
            // Turn off the dodge animation
            animatorPlayerDodge.SetBool("Dodge", false);
        }

     IEnumerator WaitForDodge2()
        {
            dodgeButtonDisabled = true;
            // Wait for the specified duration
            yield return new WaitForSeconds(dodgeDuration);
            // Turn off the dodge animation
            animatorEnemyDodge.SetBool("Dodge", false);
        }
}
