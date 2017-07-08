using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private Animator myAnimator;
    private AudioSource backSound;
 
    public PlayerController playercontroller;
   
    // Use this for initialization
	void Start () {
        backSound= GameObject.Find("Background").GetComponent<AudioSource>();
        playercontroller = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        myAnimator = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           
            backSound.Stop();
            myAnimator.SetBool("isAttack", true);
            playercontroller.dead(1);


        }
    }
}
