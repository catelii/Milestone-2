using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public bool destruir;
    public GameObject efeito;
    public Transform trilha;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Inimigo")
        {
            Life life = col.gameObject.GetComponent<Life>();
            life.DiminuirVida(200);
        }

        if (destruir)
        {
            GameObject explosaoGbj = Instantiate<GameObject>(efeito, transform.position, Quaternion.identity);
            trilha.SetParent(explosaoGbj.transform);
            Destroy(gameObject);
        }
    }
}
