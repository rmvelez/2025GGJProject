using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerStats>().SubtractHealth(2);
            Destroy(gameObject);
        }
        
        else if (collider.CompareTag("Catch"))
        {
            PlayerStats.instance.AddZ(25);
            Destroy(gameObject);
        }
    }
}
