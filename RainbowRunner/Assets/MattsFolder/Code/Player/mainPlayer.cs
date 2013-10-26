using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour {
	
	//Speed
	float offColorSpeed = 0.0f;
	float onColorSpeed = 0.0f;
	float currentSpeed = 0.0f;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void OnCollisionEnter(Collision other)
    {
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
			
            
        }
		
		//Multiplyer up
		if (other.gameObject.tag == "")
        {
            //Up Multiplyer

        }
    }
}
