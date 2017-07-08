using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public bool doublePoints;
    public bool safeMode;
    public bool timeslow;
    public float powerupLength;
    private AudioSource powerSound;
    private PowerUpManager thePowerupManager;
    public Sprite[] powerupSprites;

	// Use this for initialization
	void Start () {
        thePowerupManager = FindObjectOfType<PowerUpManager>();
        powerSound = GameObject.Find("powerup").GetComponent<AudioSource>();
    }
    private void Awake()
    {
        int powerupselector = Random.Range(0, 3);
        switch(powerupselector)
        {
            case 0: doublePoints = true;
                break;
            case 1: safeMode = true;
                break;
            case 2: timeslow = true;
                break;

        }
        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupselector];
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="Player")
        {
            powerSound.Play();
            thePowerupManager.ActivatePowerup(doublePoints,safeMode,timeslow,powerupLength);
            gameObject.SetActive(false);

        }
        
    }
}
