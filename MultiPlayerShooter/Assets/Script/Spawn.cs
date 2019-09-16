using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour
{
    [SerializeField] GameObject inimigoPrefab;
    [SerializeField] int numeroInimigos;

    public override void OnStartServer()
    {
        for (int i = 0; i < numeroInimigos; i++)
        {
            Vector3 posicaoSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 0.8f));
            Quaternion rotacaoSpawn = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0.0f);

            GameObject Inimigo = (GameObject)Instantiate(inimigoPrefab, posicaoSpawn, rotacaoSpawn);
            NetworkServer.Spawn(Inimigo);
        }
    }
}
