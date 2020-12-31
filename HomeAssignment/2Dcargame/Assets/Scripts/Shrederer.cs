using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrederer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D otherObject)
    {

    }

    
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
    }
         
}
