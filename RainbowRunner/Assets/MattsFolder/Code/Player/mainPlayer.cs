using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour {
	
	public GameObject Player;
	
	//Current postion and Scale
	float yPostion = 1.3f;
	float xPostion = -4.0f;
	float zPostion = -1.0f;
	float playerScale = 2.0f;
	
	//current lane
	int currentLane = 0;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Movement down
		if(Input.GetKeyDown(KeyCode.S) && currentLane != -5)
		{
			//Move player Down
			yPostion -= 0.6f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			//Scale player up
			playerScale += 0.2f;
			Player.transform.localScale = new Vector3(playerScale,playerScale,1.0f); 
			//change current lane
			currentLane = currentLane - 1;
		}
		//Movement up
		if(Input.GetKeyDown(KeyCode.W) && currentLane != 0)
		{
			//Move player up
			yPostion += 0.6f;
			Player.transform.position = new Vector3(xPostion,yPostion,zPostion);
			//Scale player down
			playerScale -= 0.2f;
			Player.transform.localScale = new Vector3(playerScale,playerScale,1.0f);
			//change current lane
			currentLane = currentLane + 1;	
		}
	}
	
	public void OnCollisionEnter(Collision other)
    {
		#region object collison
		//Mean Cloud
        if (other.gameObject.tag == "")
        {
			//Reduce Time
			//Reset Multiply		
			//Add Stumbles
        }
		//Gold Coin
		if (other.gameObject.tag == "")
        {
			//Add Coin
        }
		//Empty Kettle
		if (other.gameObject.tag == "")
        {
			//
			//Reset Multiply
			//Add Stumbles
        }
		//Add Time
		if (other.gameObject.tag == "")
        {
			//Add Time
			//AddTime(10);
		}
		//Multiplyer up
		if (other.gameObject.tag == "")
        {
            //Up Multiplyer
        }
		#endregion
		
		#region lane collision
		if (other.gameObject.tag == "")
        {

        }
		if (other.gameObject.tag == "")
        {

        }
		if (other.gameObject.tag == "")
        {

        }
		if (other.gameObject.tag == "")
        {

        }
		if (other.gameObject.tag == "")
        {

        }
		if (other.gameObject.tag == "")
        {

        }
		#endregion
    }
}
