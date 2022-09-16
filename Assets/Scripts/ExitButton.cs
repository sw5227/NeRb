using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    private Button button;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }


    void Clicked()
    {

        Application.Quit();
    }
}
