using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCatch : MonoBehaviour
{
    PlayerStats stats;

    private void Awake()
    {
        stats = GetComponentInParent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider projectile)
    {
        if (projectile.CompareTag("Projectile"))
        {
            stats.AddZ(25);
            Destroy(projectile);
        }
    }
}
