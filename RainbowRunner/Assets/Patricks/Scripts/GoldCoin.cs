using UnityEngine;
using System.Collections;

public class GoldCoin : MonoBehaviour 
{
	
	private Vector3 startPosition, currentPosition;
	public int currentLane;
	public float currentSpeed, startTime, currentTime, rotSpeed, rotPosition, fastSpeed, slowSpeed, startPos;
	private bool fast, slow;
	
	// Use this for initialization
	void Start () 
	{
		startPosition = new Vector3(30,getStartPosition(),-1);
		this.transform.position = startPosition;
		startTime = (float)Random.Range(0.0f,10.0f);
		fast = true;
		slow = false;
		currentSpeed = 0.0f;
		fastSpeed = 6.0f;
		slowSpeed = 4.0f;
		currentPosition = startPosition;
		rotSpeed = 0.01f;
		rotPosition = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(startTime < currentTime)
		{
			if(fast)
			{
				currentSpeed = fastSpeed;
			}
			else if(slow)
			{
				currentSpeed = slowSpeed;
			}
			else
			{
				currentSpeed = 0.0f;
			}
			
			
		}	
		if(this.transform.position.x > -30)
		{
			this.transform.position -= new Vector3( currentSpeed * Time.deltaTime, 0, 0);
			rotPosition += rotSpeed;
			this.transform.Rotate(0,rotPosition,0);
		}
		else if(this.transform.position.x <= -30)
		{
				currentTime = 0;
				currentSpeed = 0;
				rotPosition = 0;
				startTime = (float)Random.Range(0.0f, 10.0f);
				this.transform.position = new Vector3(30, getStartPosition(), -1);
				currentPosition = this.transform.position;
		}
		currentTime += Time.deltaTime;
	}
	
	float getStartPosition()
	{
		currentLane = Random.Range(0,-6);
		
		switch(currentLane)
		{
		case 0:
			startPos = 0.4f;	// RED
			break;
		case -1:
			startPos = -0.45f;	// ORANGE
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
			startPos = -4.0f;	// PURPLE
			break;
			
		}
		return startPos;
	}
}
