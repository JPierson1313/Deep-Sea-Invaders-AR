using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringSystem : MonoBehaviour
{
    [Header("Invader List")]
    public List<GameObject> invaders; //List of all invaders that are in the wave

    [Header("Projectile")]
    public GameObject projectile; //Projectile that the enemies will fire at the player

    [Header("Variables")]
    public float minTime = 0; //Minimum time for the Random.Range of countdownTimer
    public float maxTime = 4; //Maximum time for the Random.Range of countdownTimer
    public float fireSpeed = 300; //Speed of the projectile
    public float countdownTimer; //Countdown timer used for when to fire the projectile
    RespawnPlayerSystem rps; //RespawnPlayerSystem script

    // Start is called before the first frame update
    void Start()
    {
        //At the start, the Countdown Timer will be given a random time based on the range between the min and max times
        //We will get the component for RespawnPlayerSystem whenever the player has died or not
        countdownTimer = Random.Range(minTime, maxTime);
        rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the isDead boolean is not true, then a countdown timer will start until its less than 0
        //This would then random pick one of the enemies to fire a projectile upwards at the player and reset the countdown timer to a random range of the min and max times
        if (rps.isDead != true)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer < 0)
            {
                int index = Random.Range(0, invaders.Count);

                GameObject invader = invaders[index];

                GameObject lazer = Instantiate(projectile, invader.transform.position, invader.transform.rotation);
                lazer.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                lazer.GetComponent<Rigidbody>().AddForce(Vector3.up * fireSpeed);

                countdownTimer = Random.Range(minTime, maxTime);
            }
        } 
    }
}
