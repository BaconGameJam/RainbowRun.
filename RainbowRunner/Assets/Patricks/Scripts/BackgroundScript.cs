using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour 
{
	
	public float currTime, startTime;
	public int currentLane, prevLane;
	public Texture2D [] colors;
	private ForegroundScript [] roadScript;
	public GameObject []  road;      
	private mainPlayer playerScript;
	public GameObject player;      
	
	// checking bools objects. 
	
	
	
	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i< 3; i++)
		{
			
			roadScript[i] = road[i].GetComponent<ForegroundScript>();
			
		
		}
		playerScript = player.GetComponent<mainPlayer>();
		
		currentLane = getRandomLane();
		prevLane = currentLane;
		getColor();
		currTime = 0;
		startTime = getStartTime();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(startTime < currTime)
		{
			currentLane = getRandomLane();
			if(currentLane != prevLane)
			{
				prevLane = currentLane;
				getColor();
				currTime = 0;
				startTime = getStartTime();
			}			
		}
		currTime += Time.deltaTime;
		checkBools();
	}
	void getColor()
	{
		switch(currentLane)
		{
		case 0:
			this.renderer.material.mainTexture = colors[0];
			break;
		case -1:
			this.renderer.material.mainTexture = colors[1];
			break;
		case -2:
			this.renderer.material.mainTexture = colors[2];
			break;
		case -3:
			this.renderer.material.mainTexture = colors[3];
			break;
		case -4:
			this.renderer.material.mainTexture = colors[4];
			break;
		case -5:
			this.renderer.material.mainTexture = colors[5];
			break;
		}
	}
	
	float getStartTime()
	{
		float tempTime = (float)Random.Range(0.0f,20.0f);
		return tempTime;
			
	}
	int getRandomLane()
	{
		int tempLane = Random.Range(0,-6);
		return tempLane;
	}
	
	void checkBools()
	{
		if(playerScript.currentLane == currentLane)
		{
			for(int i = 0; i < 3; i++)
			{
			roadScript[i].fast = true;
			roadScript[i].slow = false;
			}
		}
		else
		{
			for(int i = 0; i < 3; i++)
			{
			roadScript[i].fast = false;
			roadScript[i].slow = true;
			}
		}
	}
}
