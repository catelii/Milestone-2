using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolherArma : MonoBehaviour
{
    public GameObject[] escolher;
    int armapadrao;
    void Update()
    {
       if (Input.GetMouseButtonDown(1))
        {
            Trocar();
        }
    }

    void Trocar()
    {
        armapadrao = (armapadrao + 1) % escolher.Length;

        for (int i = 0; i <escolher.Length; i++)
        {
            if (i != armapadrao)
            {
                escolher[i].SetActive(false);
            } else {
                escolher[i].SetActive(true);
            }
        }
    }
}
