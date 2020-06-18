using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform tpsPlayer;
    Transform tps;

    public float velocidadeRot;

    void Awake()
    {
        tps = GetComponent<Transform>();

        GameObject PlayerObj = GameObject.FindWithTag("Player");
        tpsPlayer = PlayerObj.GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        tps.position = tpsPlayer.position;

        float movimentoX = Input.GetAxis("Mouse X");
        tps.Rotate(0, movimentoX * velocidadeRot * Time.deltaTime, 0);
    }
}
