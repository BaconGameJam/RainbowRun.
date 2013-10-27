using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour {
	
	public enum ColorState{RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE, NONE};
 	public  ColorState colorState;
	
	//Refrence Scrips
	/*private AngryCloudScript angryCloudScript;
	public  GameObject[] angryCloudObject;
	private goldCoinScript goldCoinObject;
	private KettleFullScript kettleFullColor;
	private KettleEmptyScript kettleEmptyColor;
	private ShamrockScript shamrockColor;
	private TimeClockScript timeClock;*/          
	//Game Objects
	public GameObject Player;
	
	//Current postion and Scale
	float yPostion = 1.2f;
	float xPostion = -4.0f;
	float zPostion = -1.0f;
	float playerScale = 2.0f;
	float bacon = 0.001f;
	
	//current lane
	public int currentLane = 0;
	
	// Use this for initialization
	void Start () 
	{
		//angryCloudScript = angryCloudObject[0].GetComponent<AngryCloudScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		bacon *= -1;
		Player.transform.position += new Vector3( bacon,0,0);
		
			
			//Movement down
		if(Input.GetKeyDown(KeyCode.S) && currentLane != -5)
		{
			//Move player Down
			yPostion -= 0.8f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			//Scale player up
			//playerScale += 0.2f;
			//Player.transform.localScale = new Vector3(playerScale,playerScale,1.0f); 
			//change current lane
			currentLane = currentLane - 1;
			
			//switch
			getState();
		}
		//Movement up
		if(Input.GetKeyDown(KeyCode.W) && currentLane != 0)
		{
			//Move player up
			yPostion += 0.8f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			//Scale player down
			//playerScale -= 0.2f;
			//Player.transform.localScale = new Vector3(playerScale,playerScale,1.0f);
			//change current lane
			currentLane = currentLane + 1;	
			
			//switch
			getState();
		}
	}
	
	void getState()
	{
		switch(currentLane)
		{
		case 0:
			colorState = ColorState.RED;
			break;
		case -1:
			colorState = ColorState.ORANGE;
			break;
		case -2:
			colorState = ColorState.YELLOW;
			break;
		case -3:
			colorState = ColorState.GREEN;
			break;
		case -4:
			colorState = ColorState.BLUE;
			break;
		case -5:
			colorState = ColorState.PURPLE;
			break;
		}
	}
	
	/*public void OnTriggerEnter(Collider other)
    { 
		Debug.Log("fuck");
	
		
		//Mean Cloudci
        if (other.gameObject.tag == "meanMuggin")
		{
			print ("hit the cloud");
				//Reduce Time
				//Reset Multiply		
				//Add Stumble
				other.gameObject.transform.position = new Vector3 ( -30,0,-1);
		}
		
		//Gold Coin
		eif (other.gameObject.tag == "goldCoin" )
        {
			print ("hit the coin");
			//Add Coin
			other.gameObject.transform.position = new Vector3 ( -30,0,-1);
        }
		//Empty Kettle
		if (other.gameObject.tag == "kettleEmpty")
        {
			print("hit the kettle");		//
			//Reset Multiply
			//Add Stumbles
			other.gameObject.transform.position = new Vector3 ( -30,0,-1);
        }
		//Add Time
		if (other.gameObject.tag == "clock")
        {
			//Add Time
			//AddTime(10);
			other.gameObject.transform.position = new Vector3 ( -30,0,-1);
		}
		//Multiplyer up
		if (other.gameObject.tag == "Shamrock")
        {
            //Up Multiplyer
        }
		
		
	}*/
}
