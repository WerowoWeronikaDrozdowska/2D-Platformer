using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    //Referencja do tekstu
    //Referencja do PlayerHealth
    public TextMeshProUGUI CoinText;
    public CoinComponent CoinComponent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Zacząć nasłuchiwać player health event
        CoinComponent.OnCoinChanged += OnCoinChanged;
        CoinComponent.OnCoinInit += OnCoinChanged;
    }

   

    public void OnCoinChanged(int newCoin, int amountChanged)
    {
        //Debug.Log
        CoinText.text = newCoin.ToString();
    }

    //Kiedy event zostanie wywolany
    //zmienic napis
}

