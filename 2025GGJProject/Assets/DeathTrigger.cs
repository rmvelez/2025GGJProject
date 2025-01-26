using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public GameObject respawn;

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("In Trigger");

        if (player.CompareTag("Player"))
        {
            player.transform.parent.transform.position = respawn.transform.position;
            Debug.Log("Is Player Tag");
        }
    }
}
