using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentacaoInimigo : MonoBehaviour
{
    public float distanciaMinima;
    NavMeshAgent inimigo;
    public GameObject player;

    void Awake()
    {
        inimigo = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 pJogador = CameraTPS.pChao;
        Vector3 pOlharInimigo = new Vector3(pJogador.x, transform.position.y, pJogador.z);
        transform.LookAt(pJogador);
        inimigo.SetDestination(pJogador);

        float distanciaJogadorInimigo = Vector3.Distance(transform.position, pJogador);
        if (distanciaJogadorInimigo <= distanciaMinima)
        {
            inimigo.isStopped = true;
        } else {
            inimigo.isStopped = false;
        }
    }
}
