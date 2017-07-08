using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
   // public GameObject[] thePlatforms;
    public Transform generationPoint;
    private float distanceBetween;
    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private int platformSelector;
    private float[] platformWidths;
    public ObjectPooler[] theObjectPools;
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;
    public float randomSpikeThreshold;
    public float randomChestThreshold;
    public ObjectPooler spikePool;
    public ObjectPooler chestPool;
    public float powerupHeight;
    public ObjectPooler powerupPool;
    public float powerupThreshold;
    public float zombieThreshold;
    public ObjectPooler zombiePool;
    private AudioSource zombieSound;
    // Use this for initialization
    void Start()
    {
        zombieSound = GameObject.Find("zombiesound").GetComponent<AudioSource>();
        platformWidths = new float[theObjectPools.Length];
        for(int i=0;i< theObjectPools.Length;i++)
        {
            platformWidths[i]= theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (transform.position.x<generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if(heightChange>maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange<minHeight)
                {
                heightChange = minHeight;
            }
            if(Random.Range(0f,100f)<powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();
                newPowerup.transform.position = transform.position+new Vector3(distanceBetween/2f,Random.Range(powerupHeight/2,powerupHeight),0f);
                newPowerup.SetActive(true);
                //newPowerup.transform.rotation = transform.rotation;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween,heightChange,transform.position.z);
           
            //Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform= theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();
                float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2f+1f, platformWidths[platformSelector] / 2f-1f);
                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);
                newSpike.transform.position = transform.position+spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);


            }
            if (Random.Range(0f, 100f) < randomChestThreshold)
            {
                GameObject newChest = chestPool.GetPooledObject();

                float chestXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 chestPosition = new Vector3(chestXPosition, 1.0f, 0f);

                newChest.transform.position = transform.position + chestPosition;
                newChest.transform.rotation = transform.rotation;
                newChest.SetActive(true);

            }
            if (Random.Range(0f, 100f) < zombieThreshold)
            {
                GameObject newZombie = zombiePool.GetPooledObject();

                float zombieXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 zombiePosition = new Vector3(zombieXPosition-1f, 1.5f, 0f);

                newZombie.transform.position = transform.position + zombiePosition;
                newZombie.transform.rotation = transform.rotation;
                newZombie.SetActive(true);
                if (zombieSound.isPlaying)
                {
                    zombieSound.Stop();
                    zombieSound.Play();
                }
                else
                {
                    zombieSound.Play();
                }
               


            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}
