using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projetil;
    public Transform saidaProjetil;
    public float distanciaTiro, intervalo;
    public bool automatico;

    float limite1, limite2;

    void Start()
    {
        limite1 = Time.time;
        limite2 = limite1;
    }

    void Update()
    {
        limite2 = Time.time;

        if (limite2 - limite1 <= intervalo)
        {
            return;
        }

        bool deveAtirar = false;

        if (automatico)
        {
            deveAtirar = Input.GetMouseButton(0);
        } else {
            deveAtirar = Input.GetMouseButtonDown(0);
        }

        if (deveAtirar) 
        {
            limite1 = limite2;
            Atirar();
        }
    }

    void Atirar()
    {
        GameObject novoTiro = Instantiate(projetil, saidaProjetil.position, transform.rotation);
        Rigidbody novoTiro_rb = novoTiro.GetComponent<Rigidbody>();
        novoTiro_rb.AddForce(transform.forward * distanciaTiro, ForceMode.Impulse);

    }
}
