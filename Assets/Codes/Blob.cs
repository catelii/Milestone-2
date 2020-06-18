using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    Rigidbody rdb;
    public float scala = 2;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        print("bati");
        rdb.isKinematic = true;
        collision.transform.localScale = new Vector3(scala, scala, scala);
        Destroy(gameObject);
    }
}
