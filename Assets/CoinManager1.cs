using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager1 : MonoBehaviour
{
    public Text coinText;
   
    public float coinCount;
    public float pointsPerSecond;

    public bool scoreIncreasing;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            coinCount += pointsPerSecond * Time.deltaTime;
        }
        
        coinText.text = "" + Mathf.Round(coinCount);

        
    }
    public void AddScore(int pointsToAdd)
    {
        coinCount += pointsToAdd;
    }
}
