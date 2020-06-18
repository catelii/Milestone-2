using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life;
    public Sistemadesom.efeitosom efeitoDano;

    Sistemadesom sistemaDeSom;

    private void Awake()
    {
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<Sistemadesom>();
    }

    public void DiminuirVida(float dano)
    {
        life = life - dano;
        sistemaDeSom.Emitir(efeitoDano);
    }
}
