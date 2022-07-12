using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSystem : MonoBehaviour
{
    public GameObject enemyWave; //Enemy wave that the invader enemy is attached to

    [Header("Scripts")]
    public EnemyMovementSystem ms; //EnemyMovementSystem script
    public EnemyFiringSystem efs; //EnemyFiringSystem script
    GameOverScript gos; //GameOverScript script

    [Header("Animation")]
    public Animator anim; //Animation used for the invader enemy
    public float animSpeed = .2f; //Speed for the animation
    
    // Start is called before the first frame update
    void Start()
    {
        //Setting the animation speed to animSpeed and finding and getting the GameOverScript component
        anim.speed = animSpeed;
        gos = GameObject.FindGameObjectWithTag("MainGame").GetComponent<GameOverScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Colliding into a Wall object will tell the MovementSystem script to make moveUp equal true
        if(collision.gameObject.CompareTag("Wall"))
        {
            ms.moveUp = true;
        }
        
        //If an enemy is hit by the player's projectile, they will be removed from the list of the enemy wave along with subtracting 1 from the number of invaders
        else if(collision.gameObject.CompareTag("PlayerLazer"))
        {
            efs.invaders.Remove(gameObject);
            ms.numOfInvaders -= 1;
            
            //Now if the number of invaders is less than half of remaining invaders and there's more than 1 remaining,
            //Every invader destroyed will increase the horizontal and vertical movement speeds as well as the animation speed by a certain amount
            if (ms.numOfInvaders <= ms.halfOfInvadersLeft && (ms.numOfInvaders != 1))
            {
                ms.newCountDownTimerMove -= .046f;
                ms.newCountDownTimerDown -= .046f;
                animSpeed += .05f;
            }
            //When there is only one invader left, the speeds will be set to a certain amount to make it go as fast as possible while still being able to hit it
            else if (ms.numOfInvaders == 1)
            {
                ms.newCountDownTimerMove = .035f;
                ms.newCountDownTimerDown = -.23f;
            }
        }
        
        //If an invader collides with a barrier piece, then that piece will be destroyed
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(collision.gameObject);
        }
    }

    //When one of the enemies reaches the surface world, the game is over and the barriers,player, and enemy wave will be destroyed along with setting isGameOver to true 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Test");
            gos.isGameOver = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("Barrier"));
            Destroy(enemyWave); 
        }
    }
}
