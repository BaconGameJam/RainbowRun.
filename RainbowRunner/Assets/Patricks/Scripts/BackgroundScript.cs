using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour 
{
	
	public float currTime, startTime;
	public int currentLane, prevLane;
	public Texture2D [] colors;
	private ForegroundScript roadScript;
	public GameObject camera;      
	private mainPlayer playerScript;
	private GameObject player;      
	
	// checking bools objects. 
	
	
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<mainPlayer>();

		for(int i = 0; i< 3; i++)
		{		
		
			roadScript = camera.GetComponent<ForegroundScript>();
		}
		
		currentLane = getRandomLane();
		prevLane = currentLane;
		getColor();
		currTime = 0;
		startTime = getStartTime();
		changed = false;
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
		if(changed)
		{
			checkBools();
			changeOthers();
		}
	}
	void changeOthers()
	{
		
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
		if(playerScript.currentLane == currentLane )
		{
			roadScript.fast = true;
			roadScript.slow = false;
			changed = false;			
		}
		else
		{
			changed = false;
			roadScript.fast = false;
			roadScript.slow = true;
			
		}
	}
}
