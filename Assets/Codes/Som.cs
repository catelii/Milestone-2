using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip clipesom;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSrc.clip = clipesom;
        audioSrc.Play();
        Destroy(gameObject, clipesom.length);
    }
}
