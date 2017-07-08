using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestpickup : MonoBehaviour {
    public int scoreToGive;
    private CoinManager1 thecoinManager;
    private AudioSource chestSound;
    
    // Use this for initialization
    void Start () {
        thecoinManager = FindObjectOfType<CoinManager1>();
               chestSound = GameObject.Find("ChestOpen").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            thecoinManager.coinCount += scoreToGive;
            gameObject.SetActive(false);
            if (chestSound.isPlaying)
            {
                chestSound.Stop();
                chestSound.Play();
            }
            else
            {
                chestSound.Play();
            }
        }
    }
}
