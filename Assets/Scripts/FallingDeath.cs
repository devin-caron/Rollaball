using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingDeath : MonoBehaviour
{
    private Transform player;
    private Rigidbody playerRB;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Master").GetComponent<GameMaster>();
        player = GameObject.Find("Player").transform;
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            player.transform.position = gm.lastCheckPointPos;
            Physics.SyncTransforms();
            playerRB.velocity = Vector3.zero;
            playerRB.angularVelocity = Vector3.zero;
            
        }
    }
}
