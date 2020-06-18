using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosão : MonoBehaviour
{
    public float forcaExplosao;
    void Start()
    {
        RaycastHit[] hits;

        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.rigidbody)
            {
                hit.rigidbody.AddExplosionForce(forcaExplosao, transform.position, 10);
            }

            if(hit.transform.gameObject.tag == "Inimigo")
            {
                Life lifeInimigo = hit.transform.gameObject.GetComponent <Life>();
                lifeInimigo.DiminuirVida(20);
            }
        }

        Destroy(gameObject, 1.5f);
    }
}
