using UnityEngine;
using System.Collections;

public class goldCoinScript : MonoBehaviour 
{
	public GameObject player;
	private mainPlayer playerScript;
	public GameObject goldcoin;
	public float rotSpeed, slowSpeed, fastSpeed, currSpeed, rotpos, 
	currTime, startTime, startPos;
	private Vector3 endPos, startP;
	private int coinCount, maxCoins;
	public bool goingSlow, goingFast;
    public int tempStart;
	// USED TO TRACK THE CURRENT ROW OF THE OBJECT SO PLAYER CANNOT COLLECT IF NOT ON THE SAME ROW
	public enum ColorState{RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE, NONE};
	public ColorState colorState;
	

	// Use this for initialization
	void Start () 
	{
		
		rotSpeed = 0.01f;
		slowSpeed = 4.0f;
		fastSpeed = 6.0f;
		currSpeed = 0.0f;
		rotpos = 0.0f;
		startP = new Vector3(30, getStartPos(), -1);
		endPos = new Vector3(-30,startP.y,-1);
		this.transform.position = startP;
		startTime = getStartTime();
		playerScript = player.GetComponent<mainPlayer>();
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
		
		// If the coin has moved off screen to the left, reset it
		if( this.transform.position.x <= -30)
		{
			currTime = 0;
			currSpeed = 0;
			rotpos = 0;
			getStartTime();
			SetStartPosition();
			this.transform.position = startP;
		}
		rotpos += rotSpeed;
		this.transform.Rotate(0, rotpos, 0);
		//this.transform.localRotation = new Quaternion(0,rotpos,0,0);
		currTime += Time.deltaTime;

	}
	
	// Returns a float to be used for the starting Y position
	float getStartPos()
	{
		tempStart = Random.Range(0,-6);
		
		switch(tempStart)
		{
		case 0:
			startPos = 0.4f;	// RED
			colorState = ColorState.RED;
			break;
		case -1:
			startPos = -0.45f;	// ORANGE
			colorState = ColorState.ORANGE;
			break;
		case -2:
			startPos = -1.3f;	// YELLOW
			colorState = ColorState.YELLOW;
			break;
		case -3:
			startPos = -2.2f;	// GREEN
			colorState = ColorState.GREEN;
			break;
		case -4:
			startPos = -3.0f;	// BLUE
			colorState = ColorState.BLUE;
			break;
		case -5:
			startPos = -4.0f;	// PURPLE
			colorState = ColorState.PURPLE;
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
	/*public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player" && tempStart == playerScript.currentLane)
		{
			print ("hit the player");
			this.gameObject.transform.position = endPos;
		}
	}*/
}
