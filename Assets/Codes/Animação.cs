using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animação : MonoBehaviour
{
    public IA intel;
    public Sistemadesom.efeitosom efeitoSonoro;

    Sistemadesom sistemaDeSom;

    private void Awake()
    {
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<Sistemadesom>();
    }


    public void AttackAnima ()
    {
        intel.Attack();
    }

    public void animEvt_efeitoSonoro()
    {
        sistemaDeSom.Emitir(efeitoSonoro);
    }

}
