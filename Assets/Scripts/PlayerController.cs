using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movespeed;
    public float jumpforce;
    private Rigidbody2D myRigidbody;
    public bool grounded;
    public LayerMask WhatIsGround;
    
    private Animator myAnimator;
    public float jumpTime;
    private float jumpTimeCounter;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public Transform groundCheck;
    public float groundCheckRadius;
    private AudioSource jumpSound;
    private AudioSource deadsound;
   //private bool stoppedJumping;
    private bool canDoubleJump;
    private ScoreManager theScoreManager;
    private LevelManager levelmanager;
    public Transform jump1Point;
    public Transform jump2Point;
    public Transform jump3Point;
    public Transform coinPoint;
    public Transform spikepoint;
    public Transform powerpoint;

    public Zombie zombie;
   
   
    // Use this for initialization
    void Start () {
      
        myRigidbody = GetComponent<Rigidbody2D>();
     
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        deadsound = GameObject.Find("deathSound").GetComponent<AudioSource>();
        //stoppedJumping = true;
        theScoreManager = FindObjectOfType<ScoreManager>();
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        zombie = GameObject.FindObjectOfType<Zombie>();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x==jump1Point.position.x)
        {
            Time.timeScale = 0;
            Debug.LogWarning("ho gaya");
        }

            //grounded = Physics2D.IsTouchingLayers(myCollider, WhatIsGround);
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            movespeed = movespeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(movespeed, myRigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
        
                if (grounded)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpforce);
                if (jumpforce != 0)
                {
                    if (jumpSound.isPlaying)
                    {
                        jumpSound.Stop();
                        jumpSound.Play();
                    }
                    else
                    {
                        jumpSound.Play();
                    }
                }
                    //stoppedJumping = false;
                }
                if (!grounded && canDoubleJump)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpforce);
                    jumpTimeCounter = jumpTime;
                    //stoppedJumping = false;
                    canDoubleJump = false;
                }
            }
            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))) /*&&!stoppedJumping*/
            {
                if (jumpTimeCounter > 0)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpforce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                jumpTimeCounter = 0;
                //stoppedJumping = true;
            }
            if (grounded)
            {
                jumpTimeCounter = jumpTime;
                canDoubleJump = true;
            }
            myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
            myAnimator.SetBool("Grounded", grounded);

        }
    
   
   public void dead(int isDead)
    {
        
        myAnimator.SetBool("isdead", true);
        deadsound.Play();
            movespeed = 0f;
        jumpforce = 0f;
            theScoreManager.scoreIncreasing = false;
            StartCoroutine(Wait());
       
            
        
    }
    IEnumerator Wait()
    {   
        yield return new WaitForSeconds(0.6f);
        levelmanager.LoadLevel("Lose");
    }
   
}
