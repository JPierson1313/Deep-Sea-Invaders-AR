using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public Animator anim; //Animation use for the lazer
    public float animSpeed = .2f; //Speed of the animation
    public GameObject explosion; //Explosion game object

    //Sets the animation speed of the lazer to animSpeed value
    void Start()
    {
        anim.speed = animSpeed;

    }
    
    //If the lazer collides with a barrier or player, it'll destroy iself and the object it collides with as well as create an explosion game object in its wake
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Barrier"))
        {
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
        //When it collides into a wall, it'll create an explosion game object and destroy itself
        else
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
