using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public PickupType type;


    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            switch (type)
            {
                case PickupType.Health:
                    player.GetComponent<PlayerStats>().AddHealth(1);
                    Destroy(gameObject);
                    break;

                case PickupType.Z:
                    player.GetComponent<PlayerStats>().AddZ(25);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}

public enum PickupType
{
    Health,
    Z
}