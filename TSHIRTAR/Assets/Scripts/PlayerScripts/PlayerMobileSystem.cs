using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileSystem : MonoBehaviour
{
    [Header("Player Components")]
    public Rigidbody rb; //Rigidbody
    public Transform barrelEnd; //Transform where the projectile is fired from
    public GameObject projectile; //Projectile object
    public Animator anim; //For the screw rotating animation

    [Header("Variables")]
    public float moveSpeed = 10; //Speed of the player moving
    public float fireSpeed = 100; //How fast the projectile is moving
    float animSpeed = .2f; //How fast is the animation going
    public bool canFire; //If the player can fire another projectile or not

    RespawnPlayerSystem rps; //RespawnPlayerSystem script
    bool canMoveLeft; //Used for the left button when pressed/released
    bool canMoveRight; //Used for the right button when pressed/released
    
    // Start is called before the first frame update
    void Start()
    {
        //At the start, we will get the components for the RespawnPlayerSystem script and Rigidbody as well as setting the animation speed to animSpeed
        rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
        rb = gameObject.GetComponent<Rigidbody>();
        anim.speed = animSpeed;
    }
    
    //Player will move and rotate in the direction of whatever button is being pressed and held down while going at a specific speed in said direction
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;
        
        if (canMoveLeft == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveDirection.x -= moveSpeed;
        }

        if (canMoveRight == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveDirection.x += moveSpeed;
        }
        rb.velocity = moveDirection * Time.deltaTime;
    }

    //When left button is being held down
    public void HoldLeftButton()
    {
        canMoveLeft = true;
    }
    
    //When right button is being held down
    public void HoldRightButton()
    {
        canMoveRight = true;
    }
    
    //When left button is released
    public void ReleaseLeftButton()
    {
        canMoveLeft = false;
    }
    
    //When right button is released
    public void ReleaseRightButton()
    {
        canMoveRight = false;
    }
    
    //When the player presses the fire button, a projectile will be instantiated and launched from the Barrel End downwards
    public void FireButton()
    {
        if (!canFire)
        {
            GameObject lazer = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
            lazer.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
            lazer.GetComponent<Rigidbody>().AddForce(Vector3.down * fireSpeed);
            canFire = true;
        }
    }

    //If the player collides with enemy projectiles, then isDead is set to true, lose a life and be destroyed by the projectile
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyLazer"))
        {
            rps.isDead = true;
            rps.livesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
