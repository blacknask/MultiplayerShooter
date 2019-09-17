using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Vida : NetworkBehaviour
{
    [SerializeField] const int vidaMaxima = 100;
    [SyncVar(hook = "AtualizaBarraVida")] [SerializeField] int vidaAtual;
    [SerializeField] RectTransform barravida;
    [SerializeField] bool Respawn;

    NetworkStartPosition[] pontosSpawn;

    private void Start()
    {
        vidaAtual = vidaMaxima;
        if (isLocalPlayer)
        {
            pontosSpawn = FindObjectsOfType<NetworkStartPosition>();
        }
    }


    public void Damage(int quantidade)
    {
        if (!isServer) return;

        vidaAtual -= quantidade;
        barravida.sizeDelta = new Vector2(vidaAtual * 2, barravida.sizeDelta.y);

        if(vidaAtual <= 0)
        {
            if (Respawn)
            {
                vidaAtual = vidaMaxima;
                RpcRespawn();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void AtualizaBarraVida(int vida)
    {
        barravida.sizeDelta = new Vector2(vida * 2, barravida.sizeDelta.y);
    }
    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 posicaoSpawn = Vector3.zero;
            if (pontosSpawn != null && pontosSpawn.Length > 0)
            {
                posicaoSpawn = pontosSpawn[Random.Range(0, pontosSpawn.Length)].transform.position;
            }
            transform.position = posicaoSpawn;
        }
    }
}
