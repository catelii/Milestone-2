using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistemadesom : MonoBehaviour
{
    public enum efeitosom
    {
        Espadajogador = 0,
        hit,
        Inimigoespada,
        Passosinimigos,
        Passosjogador,
    }

    public GameObject somPrefab;
    public AudioClip[] sons;

    public void Emitir(efeitosom efeito)
    {
        GameObject novaCaixa = Instantiate<GameObject>(somPrefab, transform.position, Quaternion.identity);
        Som novaCaixa_Conf = novaCaixa.GetComponent<Som>();

        int som_numero = (int)efeito;

        AudioClip somEfeitoSonoro = sons[som_numero];

        novaCaixa_Conf.clipesom = somEfeitoSonoro;
    }
}