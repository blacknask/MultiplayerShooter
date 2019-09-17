using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[RequireComponent(typeof(NavMeshAgent))]
public class Inimigo : NetworkBehaviour
{
    [SyncVar] Transform Player;
    private NavMeshAgent NavMesh;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        NavMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isServer)
            NavMesh.destination = Player.transform.position;
    }























    /*
    private GameObject Player;
    private NavMeshAgent NavMesh;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        NavMesh = GetComponent<NavMeshAgent> ();
    }

    private void Update()
    {
        if (isServer)
            NavMesh.destination = Player.transform.position;
    }
    */
}
