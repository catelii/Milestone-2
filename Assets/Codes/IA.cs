using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public enum EstadoIA
    {
        Ataque,
        Andar,
    }

    public EstadoIA estado;
    NavMeshAgent inimigo;
    Life life;
    Life lifeplayer;
    public float dano;
    public Animator anima;

    Sistemadesom sistemaDeSom;

    void Awake()
    {
        inimigo = GetComponent<NavMeshAgent>();
        life = GetComponent<Life>();
        lifeplayer = GameObject.FindWithTag("Player").GetComponent<Life>();
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<Sistemadesom>();
    }

    void Update()
    {
        if (inimigo.isStopped)
        {
            estado = EstadoIA.Ataque;
        }
        else
        {
            estado = EstadoIA.Andar;
        }

        anima.SetFloat("Velocidade", inimigo.velocity.magnitude);

        if (life.life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack ()
    {
        lifeplayer.DiminuirVida(dano);
        sistemaDeSom.Emitir(Sistemadesom.efeitosom.Inimigoespada);
    }
}
