using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour {
	public static mainPlayer Instance;
	public enum ColorState{RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE, NONE};
 	public  ColorState colorState;
	private BackgroundScript backScript;
	public GameObject background;
	private ShamrockScript shamScript;
	public GameObject sham;      
	private TimeClockScript clockScript;
	public GameObject clock;      
	private KettleFullScript fullKScript;
	public GameObject fullK;      
	private KettleEmptyScript emptyKScript;
	public GameObject emptyK;      
	private GoldCoin coinScript;
	private GameObject coin;      
	private AngryCloudScript cloudScript;
	public GameObject cloud;      

	//Game Objects
	public GameObject Player;
	
	//Current postion and Scale
	float yPostion = 1.2f;
	float xPostion = -4.0f;
	float zPostion = -1.0f;
	float bacon = 0.001f;
	bool fast, slow;
	//current lane
	public int currentLane = 0;
	
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		shamScript = sham.GetComponent<ShamrockScript>();
		clockScript = clock.GetComponent<TimeClockScript>();
		fullKScript = fullK.GetComponent<KettleFullScript>();
		emptyKScript = emptyK.GetComponent<KettleEmptyScript>();
		cloudScript = cloud.GetComponent<AngryCloudScript>();
		backScript = background.GetComponent<BackgroundScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		bacon *= -1;
		this.gameObject.transform.position += new Vector3( bacon,0,0);
		
			
			//Movement down
		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{ 
			if( currentLane != -5)
			{
			//Move player Down
			yPostion -= 0.9f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			currentLane = currentLane - 1;
			
			//switch
			getState();
			}
		}
		//Movement up
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(currentLane != 0)
			{
			//Move player up
			
			yPostion += 0.9f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			currentLane = currentLane + 1;	
			
			//switch
			getState();
			}
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
		backScript.changed = true;
	}
	
	public void OnTriggerStay(Collider other)
    { 
		
		//Mean Cloudci
        if (other.gameObject.tag == "cloud") 
		{ 
			
			if(cloudScript.tempStart == currentLane)
			{
			
				//Reduce Time
				//Reset Multiply		
				//Add Stumble
				other.gameObject.transform.position = new Vector3 ( -30,0,-1);
			}
		}
		
		//Gold Coin
		else if (other.gameObject.tag == "goldCoin")
		{ 
			coinScript = other.gameObject.GetComponent<GoldCoin>();
			if(coinScript.currentLane == currentLane)
			{
				other.transform.position = new Vector3(-30, other.transform.position.y, other.transform.position.z);
			}
        }
		
		//Empty Kettle
		else if (other.gameObject.tag == "kettleEmpty")
		{ 
			
			if( emptyKScript.tempStart == currentLane)
        	{
					//
			//Reset Multiply
			//Add Stumbles
			other.gameObject.transform.position = new Vector3 ( -30,0,-1);
        
			}
		}
		
		//Full Kettle
		else if (other.gameObject.tag == "kettleFull")
		{ 
			
			if( fullKScript.tempStart == currentLane)
        	{
			
			//Reset Multiply
			//Add Stumbles
			other.gameObject.transform.position = new Vector3 ( -30,0,-1);
        	}
		}
		
		//Add Time
		else if (other.gameObject.tag == "timeClock")
		{ 
			
			if(clockScript.tempStart == currentLane)
        	{
			//Add Time
			//AddTime(10);
			other.gameObject.transform.position = new Vector3 ( -30,0,-1);
		
			}
		}
		//Multiplyer up
		else if (other.gameObject.tag == "Shamrock" )
		{
			
			if(shamScript.tempStart == currentLane)
        	{
            //Up Multiplyer
			other.gameObject.transform.position = new Vector3(-30,0,-1);
        	}
		}
		
		
	}
}
