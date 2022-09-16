using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOutOfBounds : MonoBehaviour
{
    //public AudioClip failureSound;
    public AudioSource audioSource;
    public GameObject audioHolder;

    private float topBound = 30;
    private float lowerBound = -0.8f;


    void Start()
    {
        audioHolder = GameObject.Find("AudioHolder");
        audioSource = audioHolder.GetComponent<AudioSource>();

    }



    void Update()
    {
        if (transform.position.y < lowerBound) 
        {

            Destroy(gameObject);


        }
    }
}
