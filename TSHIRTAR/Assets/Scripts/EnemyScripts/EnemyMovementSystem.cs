using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour
{
    [Header("Bools")]
    public bool isFlipped; //Boolean used to flip the movement of the enemy wave from left to right and vice versa
    public bool moveUp = false; //Boolean used to have the enemy wave move up when they reach either edge of the screen

    [Header("Movement Speed")]
    public float moveSpeed = .2f; //Movement speed of the enemy wave

    [Header("Invader Numbers")]
    public int numOfInvaders = 35; //Max amount of enemies in the wave
    public int halfOfInvadersLeft = 16; //Used when the wave reaches more or less half of enemies to start moving them faster and faster towards the top

    [Header("Countdown Timers")]
    public float countdownTimerMovement = .75f; //Used to have the enemy wave move every x amount of seconds left or right depending on which side they are moving to
    public float countdownTimerDown = .5f; //Used to have the enemy wave move up after x amount of seconds when they are ready to move horizontally in the opposite direection
    
    public float newCountDownTimerMove = .75f; //changing timer used when there starts to be less and less enemies that'll move faster left or right
    public float newCountDownTimerDown = .5f; //changing timer used when there starts to be less and less enemies that'll move faster upwards

    RespawnPlayerSystem rps; //RespawnPlayerSystem script
    NextWaveSystem nws; //NextWaveSystem script
    
    void Start()
    {
        //Find the components of RespawnPlayerSystem and NextWaveSystem scripts
        rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
        nws = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<NextWaveSystem>();
    }

    void Update()
    {
        //If there are zero enemies, then we start a new wave along with adding 1 to the wave counter and destroy this current enemy wave game object
        if(numOfInvaders == 0)
        {
            nws.canStartNextWave = true;
            nws.waveCounter += 1;
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        //Checks to see if the player is dead or not to see if it can keep moving or has to stop
        if(rps.isDead != true)
        {
            //This controls the horizontal movement of the enemy wave moving either to the left or right depending on the isFlipped boolean and doesn't need to move upwards
            if (moveUp == false)
            {
                countdownTimerMovement -= Time.deltaTime;
                if (countdownTimerMovement < 0)
                {
                    if (isFlipped == false)
                    {
                        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
                    }

                    else
                    {
                        transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
                    }
                    countdownTimerMovement = newCountDownTimerMove;
                }
            }
            
            //This controls the enemy wave moving upwards when it reaches the edges of either side and flips the isFlipped boolean to start its horizontal movement
            else if (moveUp == true)
            {
                countdownTimerDown -= Time.deltaTime;
                if (countdownTimerDown < 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
                    isFlipped = !isFlipped;
                    countdownTimerDown = newCountDownTimerDown;
                    moveUp = false;
                }
            }
        }
    }
}
