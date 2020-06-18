using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public float dano;

    void OnTriggerEnter(Collider coli)
    {
        if (coli.gameObject.CompareTag("Inimigo"))
        {
            Life lifeinimigo = coli.gameObject.GetComponent<Life>();
            lifeinimigo.DiminuirVida(dano);
        }
    }
}
