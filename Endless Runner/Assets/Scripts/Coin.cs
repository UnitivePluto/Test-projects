using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float spinSpeed=90;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>()!= null)
        {
            Destroy(gameObject);
            return;
        }
        
        if (other.gameObject.name != "Player")
        {
            return;
        }
        
        Manager.inst.IncrementScore();
        
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0); 
    }
}
