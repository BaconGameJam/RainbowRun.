using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour {
	
	//Lane Color Enum
	enum laneColor {red,purple,blue,cyan,green,yellow};
	
	//Current Lane
	int currentLane = 0;
	
	//Current postion and Scale
	int yPostion = 0;
	int xPostion = 0;
	float playerScale = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		//Movement left
//		if(Input.GetKeyDown(KeyCode.D) && currentLane != laneColor.red)
//		{
//			//Move player Down
//			yPostion = yPostion - 0;
//			//Scale player up
//			playerScale = playerScale + 0.0;
//			//change current lane
//			currentLane = currentLane - 1;
//		}
		//Movement Right
		//if(Input.GetButtonDown(KeyCode.A) && currentLane != laneColor.yellow)
		//{
			//Move player up
			//yPostion = yPostion + 0;
			//Scale player down
			//playerScale = playerScale - 0.0;
			//change current lane
			//currentLane = currentLane + 1;	
		//}
		//Draw Player
	}
	
	public void OnCollisionEnter(Collision other)
    {
		#region object collison
//		//Mean Cloud
//        if (other.gameObject.tag == "")
//        {
//			//Reduce Time
//			//Reset Multiply		
//			//Add Stumbles
//        }
//		//Gold Coin
//		if (other.gameObject.tag == "")
//        {
//			//Add Coin
//        }
//		//Empty Kettle
//		if (other.gameObject.tag == "")
//        {
//			//
//			//Reset Multiply
//			//Add Stumbles
//        }
//		//Add Time
//		if (other.gameObject.tag == "")
//        {
//			//Add Time
//			AddTime(10);
//		}
//		//Multiplyer up
//		if (other.gameObject.tag == "")
//        {
//            //Up Multiplyer
//        }
		#endregion
		
	#region lane collision
//		if (other.gameObject.tag == "")
//        {
//
//        }
//		if (other.gameObject.tag == "")
//        {
//
//        }
//		if (other.gameObject.tag == "")
//        {
//
//        }
//		if (other.gameObject.tag == "")
//        {
//
//        }
//		if (other.gameObject.tag == "")
//        {
//
//        }
//		if (other.gameObject.tag == "")
//        {
//
//        }
		#endregion
    }
}
