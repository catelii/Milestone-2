using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subir : MonoBehaviour
{
    
    public float altura = 10;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("chao") && !other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            other.transform.Translate(0, altura, 0);
            Destroy(gameObject);
        }
    }
}
