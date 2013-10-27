using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour {
	
	public enum ColorState{RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE, NONE};
 	public ColorState colorState;
	
	//Refrence Scrips
	public AngryCloudScript cloudColor;
	public GameObject cloudObject;
	private goldCoinScript goldCoinColor;
	public GameObject goldCoinObject;
	private KettleFullScript kettleFullColor;
	public GameObject kettleFullObject;
	private KettleEmptyScript kettleEmptyColor;
	public GameObject kettleEmptyObject;
	private ShamrockScript shamrockColor;
	public GameObject shamrockObject;
	
	//Game Objects
	public GameObject Player;
	
	//Current postion and Scale
	float yPostion = 1.2f;
	float xPostion = -4.0f;
	float zPostion = -1.0f;
	float playerScale = 2.0f;
	
	//current lane
	int currentLane = 0;
	
	// Use this for initialization
	void Start () 
	{
		cloudObject = GameObject.FindWithTag("meanMuggin");
		cloudColor = cloudObject.GetComponent<AngryCloudScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Movement down
		if(Input.GetKeyDown(KeyCode.S) && currentLane != -5)
		{
			//Move player Down
			yPostion -= 0.8f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			//Scale player up
			playerScale += 0.2f;
			Player.transform.localScale = new Vector3(playerScale,playerScale,1.0f); 
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
			playerScale -= 0.2f;
			Player.transform.localScale = new Vector3(playerScale,playerScale,1.0f);
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
	
	public void OnCollisionEnter(Collision other)
    {
		#region object collison
		//Mean Cloud
        if (other.gameObject.tag == "meanMuggin" && (int)colorState == (int)cloudColor.colorState)
        {
			//Reduce Time
			//Reset Multiply		
			//Add Stumbles
			Player.transform.position = new Vector3(-2,yPostion,zPostion);
        }
		//Gold Coin
		if (other.gameObject.tag == "goldCoin")
        {
			//Add Coin
        }
		//Empty Kettle
		if (other.gameObject.tag == "kettleEmpty")
        {
			//
			//Reset Multiply
			//Add Stumbles
        }
		//Add Time
		if (other.gameObject.tag == "clock")
        {
			//Add Time
			//AddTime(10);
		}
		//Multiplyer up
		if (other.gameObject.tag == "Shamrock")
        {
            //Up Multiplyer
        }
		#endregion
		
	}
}
