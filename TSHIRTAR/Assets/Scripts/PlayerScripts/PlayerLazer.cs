using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazer : MonoBehaviour
{
    public PlayerMobileSystem ps; //PlayerMobileSystem script
    public GameObject explosion; //Explosion game object
    ScoreSystemScript ss; //ScoreSystemScript script
    
    //Getting the variables from both PlayerMobileSystem and ScoreSystemScript
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMobileSystem>();
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystemScript>();
    }
    
    //Each of these collisions will have different effects depending on what object the player lazer collides with like if they hit an enemy, 
    //then you'll score points and destroy the enemy
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Barrier") || collision.gameObject.CompareTag("EnemyLazer"))
        {
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else if(collision.gameObject.CompareTag("IShielder"))
        {
            ss.score += 10;
            ss.pointsToGetExtraLife += 10;
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else if (collision.gameObject.CompareTag("IPrickie"))
        {
            ss.score += 15;
            ss.pointsToGetExtraLife += 15;
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else if (collision.gameObject.CompareTag("IChompy"))
        {
            ss.score += 20;
            ss.pointsToGetExtraLife += 20;
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            ps.canFire = false;
        }
    }
}
