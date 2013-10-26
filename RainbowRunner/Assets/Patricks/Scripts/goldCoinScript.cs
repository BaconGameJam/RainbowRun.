using UnityEngine;
using System.Collections;

public class goldCoinScript : MonoBehaviour 
{
	
	public GameObject goldcoin;
	public float rotSpeed, slowSpeed, fastSpeed, currSpeed, rotpos, 
	currTime, startTime, startPos;
	private Vector3 endPos, startP;
	private int coinCount, maxCoins;
	public bool goingSlow, goingFast;
	

	// Use this for initialization
	void Start () 
	{
		
		rotSpeed = 0.75f;
		slowSpeed = 4.0f;
		fastSpeed = 6.0f;
		currSpeed = 0.0f;
		rotpos = 0.0f;
		startP = new Vector3(30, getStartPos(), -1);
		endPos = new Vector3(-30,startPos,-1);
		this.transform.position = startP;
		startTime = getStartTime();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if(startTime < currTime)
		{
			if(goingSlow)
			{
				currSpeed = slowSpeed;
			}
			else if(goingFast)
			{
				currSpeed = fastSpeed;
			}
			else
			{
				currSpeed = 0.0f;
				
			}
		}
		if (currSpeed != 0)
		{
			this.transform.position -= new Vector3(currSpeed * Time.deltaTime, 0,0);
		}
		
		if( this.transform.position.x <= -30)
		{
			currTime = 0;
			currSpeed = 0;
			rotpos = 0;
			getStartTime();
			this.transform.position = startP;
		}
		rotpos += rotSpeed * Time.deltaTime;
		this.transform.localRotation = new Quaternion(0,rotpos,0,0);
		currTime += Time.deltaTime;

	}
	
	float getStartPos()
	{
		int tempStart = Random.Range(0,5);
		
		switch(tempStart)
		{
		case 0:
			startPos = 0.8f;
			break;
		case 1:
			startPos = 0.0f;
			break;
		case 2:
			startPos = -0.8f;
			break;
		case 3:
			startPos = -0.16f;
			break;
		case 4:
			startPos = -0.24f;
			break;
		case 5:
			startPos = -0.32f;
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
}
