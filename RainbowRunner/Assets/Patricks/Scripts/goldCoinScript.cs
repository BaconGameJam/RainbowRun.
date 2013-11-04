using UnityEngine;
using System.Collections;

public class goldCoinScript : MonoBehaviour 
{
	public struct goldCoinClone
	{
		public Vector3 startPosition, endPosition;
		public int currentLane, currentCoin;
		public float currentSpeed, startTime, currentTime, rotSpeed, rotPosition;
		public bool fast,slow;
		
	}
	
	public GameObject goldcoin;
	public goldCoinClone [] goldCoinClones;
	private GameObject [] clonedCoins;
	public float  startPos, fastSpeed, slowSpeed, stopSpeed;
	public int coinCount, maxCoins, tempStart;
		

	// Use this for initialization
	void Start () 
	{
		maxCoins = 10;
		goldCoinClones = new goldCoinClone[maxCoins];	
		clonedCoins = new GameObject[maxCoins];
		for(int i = 0; coinCount < maxCoins; i++)
		{
			goldCoinClones[i].currentCoin = coinCount;
			goldCoinClones[i].startPosition = new Vector3(30, getStartPos(), -1);
			goldCoinClones[i].startTime = getStartTime();
			goldCoinClones[i].fast = true;
			goldCoinClones[i].slow = false;
			goldCoinClones[i].currentSpeed = 0.0f;
			goldCoinClones[i].currentLane = tempStart;
			goldCoinClones[i].rotSpeed = 0.1f;
			goldCoinClones[i].currentTime = 0.0f;
			clonedCoins[i] = Instantiate(goldcoin, goldCoinClones[i].startPosition, Quaternion.identity) as GameObject;
					
			coinCount++;
		}
		
		
		slowSpeed = 4.0f;
		fastSpeed = 6.0f;
		stopSpeed = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		for(int i = 0; i < maxCoins; i++)
		{
			if(goldCoinClones[i].startTime < goldCoinClones[i].currentTime)
			{
				if(goldCoinClones[i].fast)
				{
					goldCoinClones[i].currentSpeed = fastSpeed;
				}
				else if(goldCoinClones[i].slow)
				{
					goldCoinClones[i].currentSpeed = slowSpeed;
				}
				else
				{
					goldCoinClones[i].currentSpeed = 0.0f;
				}
				
				if(goldCoinClones[i].currentSpeed != 0)
				{
					if(clonedCoins[i].transform.position.x > -30)
					{
						goldCoinClones[i].rotPosition += goldCoinClones[i].rotSpeed;
						clonedCoins[i].transform.position -= new Vector3(goldCoinClones[i].currentSpeed * Time.deltaTime, 0 , 0);
						clonedCoins[i].transform.Rotate(0,goldCoinClones[i].rotPosition, 0);
					}
					else if(clonedCoins[i].transform.position.x <= -30)
					{
						goldCoinClones[i].currentTime = 0;
						goldCoinClones[i].startPosition = new Vector3(30, getStartPos(), -1);
						goldCoinClones[i].startTime = getStartTime();
						clonedCoins[i].transform.position = goldCoinClones[i].startPosition;
					}
				}
			}
			goldCoinClones[i].currentTime += Time.deltaTime;
		}
	}
	
	// Returns a float to be used for the starting Y position
	float getStartPos()
	{
		tempStart = Random.Range(0,-6);
		
		switch(tempStart)
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
	
	float randomTime()
	{
		float tempTime  = Random.Range(0,10.0f);
		return tempTime;
	}
	float getStartTime()
	{
		
		float startTime = randomTime();
		return startTime;
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
