using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour
{
    
    private LevelManager levelManager;
    private ScoreManager theScoreManager;
    

    // Use this for initialization
    void Start()
    {
       
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D()
    {
        theScoreManager.scoreIncreasing = false;

        
        levelManager.LoadLevel("Lose");
        
    }
}