using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] GameObject projetil;
    [SerializeField] Transform projetilspawn;
    [SerializeField] float velocidadeReotacao;
    [SerializeField] float velocidade;
    float x, y;

    void Update()
    {
        if (!isLocalPlayer) return;

        x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, y);

            if (Input.GetButtonDown("Fire1"))
            {
                CmdFire();
            }

    }
    [Command]
    void CmdFire()
    {
        GameObject tiro = (GameObject)Instantiate(projetil, projetilspawn.position, projetilspawn.rotation);
        tiro.GetComponent<Rigidbody>().velocity = tiro.transform.forward * 10.0f;

        NetworkServer.Spawn(tiro);

        Destroy(tiro, 2.0f);
    }
    
}
