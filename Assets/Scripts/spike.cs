using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    private AudioSource backSound;


    public PlayerController playercontroller;
   
    // Use this for initialization
    void Start()
    {
        backSound = GameObject.Find("Background").GetComponent<AudioSource>();
        playercontroller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            backSound.Stop();
            playercontroller.movespeed = 0f;
            playercontroller.jumpforce = 0f;
            playercontroller.dead(1);

        }
    }
}
