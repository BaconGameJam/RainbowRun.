using UnityEngine;
using System.Collections;


public class ScriptTime : MonoBehaviour {
	
	public float timeRemaining;
	public GUIStyle timeStyle;
	
	private bool fontBoost;
	private float fontBoostTime;
	private int smallTextOffset, largeTextOffset;

	// Use this for initialization
	void Start () {
		smallTextOffset = 100;
		largeTextOffset = 200;
		GUI.color = Color.red;
		fontBoost = false;
		fontBoostTime = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeRemaining -= Time.deltaTime;
		
		// For testing
		if(timeRemaining <= 0.0f)
		{
			AddTime(10.0f);	
		}
		
		if(fontBoost)
		{
			if(fontBoostTime > 0.0f)
			{
				fontBoostTime -= Time.deltaTime;	
			}
			else
			{
				fontBoost = false;
				timeStyle.fontSize = 50;
				timeStyle.normal.textColor = Color.red;
			}
		}
	}
	
	// DISPLAY THE TIME REMAINING
	void OnGUI()
	{
		if(fontBoost)
		{
			GUI.Label(new Rect((Screen.width / 2) - largeTextOffset, 50, 400, 20), 
				"Time: " + timeRemaining.ToString("F2"), timeStyle);
		}
		else
		{
			GUI.Label(new Rect((Screen.width / 2) - smallTextOffset, 50, 400, 20), 
				"Time: " + timeRemaining.ToString("F2"), timeStyle);
		}
	}
	
	// ADD TIME TO THE REMAINING TIME
	void AddTime(float plusTime)
	{
		timeRemaining += plusTime;
		timeStyle.fontSize = 100;
		fontBoost = true;
		fontBoostTime = 0.5f;
		timeStyle.normal.textColor = Color.white;
	}
}
