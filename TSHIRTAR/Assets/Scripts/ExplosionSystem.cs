using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //When the explosion object is created, this script will set the object's parent to Image Target and destroy itself after 0.2 seconds
        transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
        Destroy(gameObject, .2f);
    }
}
