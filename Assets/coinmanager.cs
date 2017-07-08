using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinmanager : MonoBehaviour
{
    public Text coinText;

    

    public int highcoinCount;
    public int coinCount;
    // Use this for initialization
    void Start()
    {
        coinCount= PlayerPrefs.GetInt("Coins");
        highcoinCount = PlayerPrefs.GetInt("TotalCoins");
        addcoinstext();
    }

    // Update is called once per frame
    void Update()
    {
        



    }
   public void addcoinstext()
    {
        for (int i = 1; i <= coinCount; i++)
        {
            coinText.text = "X" + " " + Mathf.Round(highcoinCount) + i;

        }
        highcoinCount = highcoinCount + coinCount;
        PlayerPrefs.SetInt("TotalCoins", highcoinCount);
        PlayerPrefs.SetInt("Coins", 0);
    }
   
}
