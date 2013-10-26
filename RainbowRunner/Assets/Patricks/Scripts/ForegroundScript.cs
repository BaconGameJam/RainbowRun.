using UnityEngine;
using System.Collections;

public class ForegroundScript : MonoBehaviour 
{
	public GameObject [] prefabList;
	
	private float slowSpeed, fastSpeed;
	private float startPos, finalPos;
	private float velocity;
	private bool slowRunner, fastRunner;
	// Use this for initialization
	void Start () 
	{
		
		slowSpeed = 0.5f;
		fastSpeed = 1.0f;
		velocity = 	0.25f;
		startPos = 24;
		finalPos = -24;
		slowRunner = true;
		fastRunner = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		for(int i = 0; i < prefabList.Length; i++)
		{
			if(prefabList[i].transform.position.x >= -24)
			{
				if(slowRunner)
				{
					prefabList[i].transform.position -= new Vector3(slowSpeed * velocity,0,0);
				}
				else if(fastRunner)
				{
					
					prefabList[i].transform.position -= new Vector3(fastSpeed * velocity,0,0);
				}
			}
			else
			{
				prefabList[i].transform.position = new Vector3(24,0,0);
			}
		}
	
	}
}
