using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirarInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("chao") && !other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.gameObject.transform.rotation = Quaternion.identity;
            other.gameObject.AddComponent<CharacterController>();
            var IA = other.gameObject.AddComponent<MovimentacaoInimigo>();
            IA.player = FindObjectOfType<MovimentacaoInimigo>().gameObject;
            Destroy(gameObject);
        }
    }
}
