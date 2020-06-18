using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{
    public Vector2 rotacao;
    public float vel, altura;
    public LayerMask camada;

    public static Vector3 pChao = Vector3.zero;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rot = transform.eulerAngles;

        rot.y += mouseX * rotacao.x * Time.deltaTime;
        rot.x -= mouseY * rotacao.y * Time.deltaTime;
        rot.z = 0;

        transform.eulerAngles = rot;

        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        transform.Translate(movH * vel * Time.deltaTime, 0, movV * vel * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, camada))
        {
            pChao = hit.point;
            pos.y = pChao.y * altura;
        }
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
    }
}
