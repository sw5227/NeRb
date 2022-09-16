using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool isLeftHand = true;
    public GameObject mainMenuUI = null;
    public GameObject inGameUI = null;
    public GameObject audioHolder;
    public TextMeshProUGUI scoreText;
    public AudioClip music;
    public AudioSource audioSource;
    

    private int score;
    private SpawnManager spawnManager = null;
    private GestureTracker gestureTracker = null;


    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    void Start()
    {
        audioHolder = GameObject.Find("Main Camera");
        audioSource = audioHolder.GetComponent<AudioSource>();
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        gestureTracker = GameObject.FindObjectOfType<GestureTracker>();
        mainMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);

        score = 0;
        UpdateScore(0);

    }

    public void StartGame(bool isLeftHand)
    {
        this.isLeftHand = isLeftHand;
        //Debug.Log("is this left hand? : " + this.isLeftHand);
        audioSource.clip = music;
        audioSource.Play();
        spawnManager.StartSpawning();
        mainMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        gestureTracker.StartGestureTracker(this.isLeftHand);

    }

    public void QuitGame()
    {
        audioSource.Stop();
        spawnManager.StopSpawning();
        mainMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gestureTracker.QuitGestureTracker();
    }

}
