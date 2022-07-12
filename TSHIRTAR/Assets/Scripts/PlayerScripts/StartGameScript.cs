using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public NextWaveSystem nws; //NextWaveSystem script
    public RespawnPlayerSystem rps; //RespawnPlayerSystem script
    public ScoreSystemScript sss; //ScoreSystemScript script
    
    //When the player clicks on the button, the game will start with allowing the enemy wave system to start making waves and setting the wave counter to 1,
    //Setting the lives and lives text up along with resetting both the score and points to get an extra life to 0,
    //And turning off the Start Screen Canvas off
    public void PressStartButton()
    {
        nws.canStartNextWave = true;
        nws.waveCounter = 1;
        rps.livesLeft = 3;
        rps.livesText.text = "LIVES:" + rps.livesLeft.ToString();
        sss.score = 0;
        sss.pointsToGetExtraLife = 0;
        this.gameObject.SetActive(false);
    }
}
