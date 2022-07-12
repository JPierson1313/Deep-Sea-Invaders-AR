using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnPlayerSystem : MonoBehaviour
{
    [Header("Player")]
    public GameObject player; //Player game object

    [Header("Lives Text")]
    public TextMeshPro livesText; //Text for the lives

    [Header("Variables")]
    public bool isDead = false; //Boolean to check if the Player is dead
    public float restartTimer = .5f; //Timer for when the game can start again on the current level
    public int livesLeft = 3; //Amount of lives left

    [Header("GameOverScript")]
    public GameOverScript gos; //GameOverScript script

    // Update is called once per frame
    void Update()
    {
        //Checks to see if the isDead is true and there still lives left
        if (isDead == true && livesLeft > 0)
        {   
            //If yes, we will update the Lives text to the current amount of lives left and have the restart timer counting down
            //When the timer is less than 0, we will instantiate a new Player ship, set its parent to the Image Target
            //And set the timer back to 1 second and isDead to false
            livesText.text = "LIVES:" + livesLeft.ToString();
            restartTimer -= Time.deltaTime;
            if(restartTimer < 0)
            {
                GameObject newShip = Instantiate(player, transform.position, transform.rotation);
                newShip.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                restartTimer = 1f;
                isDead = false;
            }
        }
        
        //If there are no lives left, then we will set isGameOver to true, destroy the barrier and enemy game objects and set livesLeft to -1 to make sure the game doesn't create another player game object
        if(livesLeft == 0)
        {
            livesText.text = "LIVES:" + livesLeft.ToString();
            gos.isGameOver = true;
            Destroy(GameObject.FindGameObjectWithTag("Barrier"));
            Destroy(GameObject.FindGameObjectWithTag("EnemyWave"));
            livesLeft = -1;
        }
    }
}
