using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GestureTracker;

public class DetectCollision : MonoBehaviour
{
    public AudioClip soundDo;
    public AudioClip soundRe;
    public AudioClip soundMi;
    public AudioClip soundFa;
    public AudioClip successSound;

    public AudioSource audioSource;
    public GameObject audioHolder;
    public GestureTracker gestureTracker;
    public ParticleSystem DestructionEffect;

    private GameManager gameManager;


    void Explode()
    {
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                         as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.loop = false;
        explosionEffect.Play();
        Destroy(explosionEffect.gameObject, explosionEffect.duration);
        Destroy(gameObject);

    }

    void Start()
    {
        audioHolder = GameObject.Find("AudioHolder");
        audioSource = audioHolder.GetComponent<AudioSource>();
        gestureTracker = GameObject.Find("Attachment Hands").GetComponent<GestureTracker>();
        DestructionEffect = GameObject.Find("FX_Explosion_Smoke").GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource.clip = successSound;
    }


    void Update()
    {
        
        if (transform.position.y <= 0.4f && transform.position.y >= -0.3f) 
        {



            if (gestureTracker.gest1 == true && transform.position.x == -1.5f)
            {
                gameManager.UpdateScore(1);
                audioSource.clip = soundDo;
                audioSource.Play();
                Explode();
            }
            if (gestureTracker.gest2 == true && transform.position.x == -0.5f)
            {
                gameManager.UpdateScore(1);
                audioSource.clip = soundRe;
                audioSource.Play();
                Explode();
            }
            if (gestureTracker.gest3 == true && transform.position.x == 0.5f)
            {
                gameManager.UpdateScore(1);
                audioSource.clip = soundMi;
                audioSource.Play();
                Explode();
            }
            if (gestureTracker.gest4 == true && transform.position.x == 1.5f)
            {
                gameManager.UpdateScore(1);
                audioSource.clip = soundFa;
                audioSource.Play();
                Explode();
            }



        }
    }


    
}
