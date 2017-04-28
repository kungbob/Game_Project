using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

    public static int town_level;

	void Start ()
	{
        town_level = 0;
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

}
