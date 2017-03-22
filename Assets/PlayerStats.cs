using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;
    public static float IncreaseRate = 1f;
    private float Countdown = 0f;

    public static int Lives;
    public int startLives = 20;

    // Use this for initialization
    void Start () {
        Money = startMoney;
        Lives = startLives;
	}
	
	// Update is called once per frame
	void Update () {
		

        if (Countdown <= 0)
        {
            Money += 1;
            Countdown = 1f / IncreaseRate;
        }

        Countdown -= Time.deltaTime;
    }
}
