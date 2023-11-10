using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /*  Game Controller Script
        - Manages Time
        - Ends the level based on Time/Death
        - Controls Winning/Losing
    */

    public float targetTime;
    private float currentTime;

    void Start() //Called once before the first frame update.
    {
        currentTime = targetTime;
    }

    void Update() //Called once per frame.
    {
        ReduceTime();
        OutofTime();
    }

    void ReduceTime()
    {
        
    }
    void OutofTime()
    {
        if (currentTime <= 0)
        {
            GameLost();
        }
    }
    public void GameLost()
    {

    }

    public void GameWon()
    {

    }
}
