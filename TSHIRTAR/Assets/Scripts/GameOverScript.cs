using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverLayout; //Game Over Canvas
    public GameObject startScreenLayout; //Start Screen Canvas
    public bool isGameOver = false; //Boolean used to see if there is a game over
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the boolean is true then we set the Game Over Canvas to be true
        if(isGameOver == true)
        {
            gameOverLayout.SetActive(true);
        }
    }
    
    //When the plater clicks on the button, it'll set the Game Over boolean to false while setting the Start Screen Canvas to being active and deactivating the Game Over Canvas
    public void PressRestartButton()
    {
        isGameOver = false;
        startScreenLayout.SetActive(true);
        gameOverLayout.SetActive(false);
    }
}
