using System;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    //Referencja do tekstu
    //Referencja do PlayerHealth
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Zacz¹æ nas³uchiwaæ player health event
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitialised += OnHealthInit;
    }

    private void OnHealthInit(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log
        healthText.text = newHealth.ToString();
    }

    //Kiedy event zostanie wywolany
    //zmienic napis
}
