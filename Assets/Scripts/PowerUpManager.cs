using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {
    private bool doublePoints;
    private bool safeMode;
    private bool timeslow;
    private bool powerupActive;
    private float powerupLengthCounter;
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private PlayerController theplayercontroller;
    private float normalPointsPerSecond;
    private float spikeRate;
    private float normalspeed;
    private float zombieRate;
    private PlatformDestroyer[] spikeList;
    private PlatformDestroyer[] zombieList;
    // Use this for initialization
    void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theplayercontroller = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;
            if(doublePoints)
            {
                theplayercontroller.GetComponent<SpriteRenderer>().color = Color.yellow;
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 3;
            }
            if(safeMode)
            {
                theplayercontroller.GetComponent<SpriteRenderer>().color = Color.blue;
                thePlatformGenerator.randomSpikeThreshold = 0f;
                thePlatformGenerator.zombieThreshold = 0f;
            }
            if(timeslow)
            {
                theplayercontroller.GetComponent<SpriteRenderer>().color = Color.green;
                theplayercontroller.movespeed = 10f;
            }
            if(powerupLengthCounter<=0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                thePlatformGenerator.zombieThreshold = zombieRate;
                theplayercontroller.movespeed = normalspeed;
                theplayercontroller.GetComponent<SpriteRenderer>().color = Color.white;
                powerupActive = false;
            }
        }

		
	}
    public void ActivatePowerup(bool points,bool safe,bool times,float time)
    {
        doublePoints = points;
        safeMode = safe;
        timeslow = times;
        powerupLengthCounter = time;
        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;
        normalspeed = theplayercontroller.movespeed;
        zombieRate = thePlatformGenerator.zombieThreshold;

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {   if (spikeList[i].gameObject.name.Contains("Spike"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }
            }
            zombieList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < zombieList.Length; i++)
            {
                if (zombieList[i].gameObject.name.Contains("Zombie"))
                {
                    zombieList[i].gameObject.SetActive(false);
                }
            }
        }
        powerupActive = true;
    }
}
