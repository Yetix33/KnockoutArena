using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private int start = 0;
    private bool TakingTime;
    private int time;

    private int rangeStart = 5;
    private int rangeEnd = 10;
    private System.Random randomizer;
    private int TimeOfNextPowerup;
    private bool livePowerup;

    public GameObject strengthPowerup;
    public GameObject speedPowerup;
    public GameObject blockPowerup;


    private string[] powerups = {"strength", "speed", "block"};

    // Start is called before the first frame update
    void Start()
    {
        time = start;
        livePowerup = false;
        randomizer = new System.Random();
        TimeOfNextPowerup = findNextPowerupTime();
        Debug.Log(TimeOfNextPowerup);
    }

    // Update is called once per frame
    void Update()
    {
        if (TakingTime == false) {
            StartCoroutine(TimeAdd());
        }

        if (time == TimeOfNextPowerup && livePowerup == false) {
            AddPowerup();
        }


    }

    // Find random time that next powerup should spawn at
    private int findNextPowerupTime() {
        int randTime = randomizer.Next(rangeStart, rangeEnd + 1);
        return time + randTime;
    }
    public void resetPowerupTime(){
        livePowerup = false;
        TimeOfNextPowerup = findNextPowerupTime();
    }

    private void AddPowerup() {
        int index = randomizer.Next(0, 3);
        string power = powerups[index];
        Debug.Log(index);
        livePowerup = true;
        if (power == "strength") {
            Instantiate(strengthPowerup);
            return;
        } else if (power == "speed") {
            Instantiate(speedPowerup);
            return;
        } else {
            Instantiate(blockPowerup);
            return;
        }  
    }

    // Coroutine that adds 1 second and waits for next second 
    IEnumerator TimeAdd() {
        TakingTime = true;
        yield return new WaitForSeconds(1);
        time += 1;
        // Update time display here if adding!!
        TakingTime = false;
    }
}
