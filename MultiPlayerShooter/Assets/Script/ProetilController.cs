using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProetilController : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Vida v = collision.gameObject.GetComponent<Vida>();
           v.Damage(damage);
        }
        Destroy(gameObject);
    }
}
