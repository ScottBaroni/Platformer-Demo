using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRespawn : MonoBehaviour
{
    public float respawnDelay = 5f;
    private GameObject powerupObj;

    private void Awake()
    {
        // Get first child
        powerupObj = transform.GetChild(0).gameObject;
    }

    public void Collected()
    {
        powerupObj.SetActive(false);
        StartCoroutine(WaitForRespawn());
    }

    private IEnumerator WaitForRespawn()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(respawnDelay);

        // "Respawn" powerup
        powerupObj.SetActive(true);
        Debug.Log("Respawned");
            
    }
}
