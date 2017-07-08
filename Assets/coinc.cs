using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinc : MonoBehaviour
{

    private GameObject jumpLabel;
    private PlayerController theplayercontroller;
    private float normaljump;
    private int Count;
    void Start()
    {
        Count = PlayerPrefs.GetInt("countt");
        theplayercontroller = FindObjectOfType<PlayerController>();
        jumpLabel = GameObject.Find("coincc");
        jumpLabel.SetActive(false);
        normaljump = theplayercontroller.jumpforce;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Count < 4)
        {
            PlayerPrefs.SetInt("countt", 4);
            Time.timeScale = 0;

            jumpLabel.SetActive(true);
            theplayercontroller.jumpforce = 0f;
        }

    }
    public void doit()
    {
        Time.timeScale = 1;
        jumpLabel.SetActive(false);
        theplayercontroller.jumpforce = normaljump;
    }




}

