using UnityEngine;
using System.Collections;


public class ScriptTime : MonoBehaviour {
	
	public float timeRemaining;
	public GUIStyle timeStyle;
	

	// Use this for initialization
	void Start () {
		GUI.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
	}
	
	// DISPLAY THE TIME REMAINING
	void OnGUI()
	{
		GUI.Label(new Rect((Screen.width / 2) - 100, 10, 100, 20), 
			"Time: " + timeRemaining.ToString("F2"), timeStyle);	
	}
	
	// ADD TIME TO THE REMAINING TIME
	void AddTime(float plusTime)
	{
		timeRemaining += plusTime;
	}
}
