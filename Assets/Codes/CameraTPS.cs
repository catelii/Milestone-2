using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTPS : MonoBehaviour
{

    public float velMov;
    public LayerMask camadaChao;
    public float deslocamentoAltura;
    public Animator animacao;
    public float intensidadePulo;

    public GameObject projetilMagia;
    public Transform pontoTiro;
    public float forcaLancamentoMagia;

    public static Vector3 pChao;

    public CapsuleCollider Espada;

    Transform tps;
    Transform cam;

    Rigidbody corpo;

    public bool estaNoChao;
    public bool Pulando;
    public bool Movimentando;
    public bool magiaUsada;

    void Awake()
    {
        tps = GetComponent<Transform>();
        corpo = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("BBB").GetComponent<Transform>();

        Espada.enabled = false;
    }

    void FixedUpdate()
    {
        bool pulou = Input.GetButtonDown("Jump");    
        bool ataque = Input.GetButtonDown("Fire1");
        bool magia = Input.GetButtonDown("Fire2");

        float movimentoH = Input.GetAxis("Horizontal");
        float movimentoV = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoH, 0, movimentoV);

        if (movimento.magnitude > 1f)
            movimento.Normalize();

        RaycastHit chaoHit;
        estaNoChao = Physics.Raycast
        (
            tps.position, Vector3.down, out chaoHit, deslocamentoAltura, camadaChao
        );

        Pulando = pulou || !estaNoChao;
        Movimentando = movimento.magnitude > 0.1f;

        if (ataque && !Pulando && !Espada.enabled)
        {
            animacao.SetTrigger("atacou");
            Espada.enabled = true;
            Invoke("DesativarEspada", 1f);
        }

        if(magia && !Pulando && !Espada.enabled && !magiaUsada)
        {
            animacao.SetTrigger("Magia");
            magiaUsada = true;
            Invoke("DesativaMagia", 0.2f);

            GameObject magiaGbj = Instantiate<GameObject>(projetilMagia, pontoTiro.position, pontoTiro.rotation);
            Rigidbody magiaRb = magiaGbj.GetComponent<Rigidbody>();
            magiaRb.AddForce(magiaGbj.transform.forward * forcaLancamentoMagia, ForceMode.Impulse);
        }


        corpo.useGravity = Pulando;
        corpo.constraints = (
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ
            );
        if (!Pulando)
            corpo.constraints = corpo.constraints | RigidbodyConstraints.FreezePositionY;

        if (pulou && estaNoChao)
        {
            corpo.AddForce(Vector3.up * intensidadePulo, ForceMode.Impulse);
        }


        if (Movimentando)
            tps.LookAt(tps.position + cam.TransformDirection(movimento) * 5);
        if (Movimentando)
            tps.Translate(0, 0, movimento.magnitude * velMov * Time.deltaTime);

        animacao.SetFloat("Velocidade", movimento.magnitude);
        animacao.SetBool("EstaNoChao", estaNoChao);

        if (!Pulando)
        {
            RaycastHit hit;
            bool raychao = Physics.Raycast
            (
                tps.position, Vector3.down, out hit, Mathf.Infinity, camadaChao
            );
            if (raychao)
            {
                Vector3 pos = tps.position;
                pos.y = hit.point.y + deslocamentoAltura;
                tps.position = pos;
                pChao = hit.point;
            }
            corpo.velocity = Vector3.zero;
        }
    }

    void DesativarEspada()
    {
        Espada.enabled = false;
    }

    void DesativaMagia()
    {
        magiaUsada = false;
    }
}
