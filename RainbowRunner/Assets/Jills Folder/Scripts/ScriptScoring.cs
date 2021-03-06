﻿using UnityEngine;
using System.Collections;

public class ScriptScoring : MonoBehaviour {
	
	public GUIStyle scoreStyle;
	
	private ulong score, distance, coins;

	// Use this for initialization
	void Start () {
		score = distance = coins = 0;
	}
	
	// Update is called once per frame
	void Update () {
		distance += 1;						// Update the distance every frame
		
		// CLAMP SCORE TO 0 IF LESS THAN 0
		if(score < 0)
		{
			score = 0;	
		}
		
		if(coins <= 0)						// If score is less than 0
		{
			score = distance;					// Then only use distance
		}
		else
		{
			score = distance * coins;			// Total score is distance X coins
		}
	}
	
	void AddCoin(uint addedCoins)
	{
		coins += addedCoins;	
	}
	
	// GUI FOR SCORING
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 100), 
			"Score: " + score.ToString() + 
			"\nDistance: " + distance + 
			"\nCoins: " + coins, 
			scoreStyle);	
	}
}
