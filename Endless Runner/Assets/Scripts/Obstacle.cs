using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement movement;
     

    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindObjectOfType<PlayerMovement>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            movement.dead();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
