using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystemScript : MonoBehaviour
{
    public int score = 0; //Game Score
    public int pointsToGetExtraLife; //A set of points needed to get an extra life for the player
    public TextMeshPro scoreText; //Score Text
    public RespawnPlayerSystem rps; //RespawnPlayerSystem script
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Sets the Score Text to "SCORE:" + the current score converted to string
    //When the pointsToGetExtraLife is greater than or equal to 1000, it'll call the AddLifePoint method
    void FixedUpdate()
    {
        scoreText.text = "SCORE:" + score.ToString();
        if(pointsToGetExtraLife >= 1000)
        {
            AddLifePoint();
        }
    }
    
    //An extra life will be added and lives left will be updated for the extra life added
    //pointsToGetExtraLife will also be subtracted by 1000 points to restart the point collecting process
    void AddLifePoint()
    {
        rps.livesLeft += 1;
        rps.livesText.text = "LIVES:" + rps.livesLeft.ToString();
        pointsToGetExtraLife -= 1000;
    }
}
