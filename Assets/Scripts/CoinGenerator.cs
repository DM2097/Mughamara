using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPool;
    public float distanceBetweenCoins;
    private int coinnumber;
    private float coinposistionx;
    private float coinposistiony;
    public void SpawnCoins(Vector3 startPosition)
    {
        coinnumber = Random.Range(1, 6);
        for (int i = 1; i <= coinnumber; i++)
        {
            coinposistionx = Random.Range(-distanceBetweenCoins, +distanceBetweenCoins);
            coinposistiony = Random.Range(0f, 2f);
            GameObject coin1 = coinPool.GetPooledObject();
            coin1.transform.position = new Vector3(startPosition.x + coinposistionx, startPosition.y+coinposistiony, startPosition.z);
            coin1.SetActive(true);
            
            /*GameObject coin2 = coinPool.GetPooledObject();
            coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
            coin2.SetActive(true);

            GameObject coin3 = coinPool.GetPooledObject();
            coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
            coin3.SetActive(true);*/
        }
    }
}
