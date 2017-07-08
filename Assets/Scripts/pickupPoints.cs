using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {
    public int scoreToGive;
    private CoinManager1 thecoinManager;
    private AudioSource coinSound;

    // Use this for initialization
    void Start() {
        thecoinManager = FindObjectOfType<CoinManager1>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
            }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            thecoinManager.coinCount += scoreToGive;
            gameObject.SetActive(false);
            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }
        }
    }
}
