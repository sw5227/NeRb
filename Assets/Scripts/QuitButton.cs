using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }


    void Clicked()
    {

        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.QuitGame();
    }
}
