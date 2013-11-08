using UnityEngine;
using System.Collections;

public class AngryCloudScript : MonoBehaviour 
{
	private ForegroundScript roadScript;
	private GameObject roadO;
	
	private float slowSpeed, fastSpeed, currSpeed,
		currTime, startTime, startPos;
	private Vector3  startP;
	public bool fast , slow;
	public int currentLane;

	

	// Use this for initialization
	void Start () 
	{
		roadO = GameObject.FindGameObjectWithTag("MainCamera");
		roadScript = roadO.GetComponent<ForegroundScript>();
		
		slowSpeed = 4.0f;
		fastSpeed = 6.0f;
		currSpeed = 0.0f;
		startP = new Vector3(30, getStartPos(), -1);
	
		this.transform.position = startP;
		startTime = getStartTime();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(startTime < currTime)
		{
			if(roadScript.fast)
			{
				currSpeed = fastSpeed;
			}
			else
			{
				currSpeed = slowSpeed;
			}
		}
		if (currSpeed != 0)
		{
			this.transform.position -= new Vector3(currSpeed * Time.deltaTime, 0,0);
		}
		
		// If the coin has moved off screen to the left, reset it
		if( this.transform.position.x <= -30)
		{
			currTime = 0;
			currSpeed = 0;
			getStartTime();
			SetStartPosition();
			this.transform.position = startP;
		}
		currTime += Time.deltaTime;

	}
	
	// Returns a float to be used for the starting Y position
	float getStartPos()
	{
		currentLane = Random.Range(0,-6);
		
		switch(currentLane)
		{
		case 0:
			startPos = 0.2f;	// RED
		
			break;
		case -1:
			startPos = -0.40f;	// ORANGE
		
			break;
		case -2:
			startPos = -1.3f;	// YELLOW
		
			break;
		case -3:
			startPos = -2.2f;	// GREEN
	
			break;
		case -4:
			startPos = -3.0f;	// BLUE

			break;
		case -5:
			startPos = -3.8f;	// PURPLE
			break;
			
		}
		return startPos;
	}
	
	float randomTime()
	{
		float tempTime  = Random.Range(0,10.0f);
		return tempTime;
	}
	float getStartTime()
	{
		currTime = Time.deltaTime;
		startTime = currTime + randomTime();
		return startTime;
	}
	
	void SetStartPosition()
	{
		startP = new Vector3(30, getStartPos(), -1);	
	}
	

}
