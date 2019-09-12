using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Vida : NetworkBehaviour
{
    [SerializeField] const int vidaMaxima = 100;
    [SyncVar(hook = "AtualizaBarraVida")] [SerializeField] int vidaAtual;
    [SerializeField] RectTransform barravida;


    private void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void Damage(int quantidade)
    {
        if (!isServer) return;

        vidaAtual -= quantidade;
        barravida.sizeDelta = new Vector2(vidaAtual * 2, barravida.sizeDelta.y);

        if(vidaAtual <= 0)
        {
            vidaAtual = 0;
            Debug.Log("Morreu!!!");
        }
    }
    private void AtualizaBarraVida(int vida)
    {
        barravida.sizeDelta = new Vector2(vida * 2, barravida.sizeDelta.y);
    }
}
