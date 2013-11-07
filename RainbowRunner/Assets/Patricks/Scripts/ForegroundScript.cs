using UnityEngine;
using System.Collections;

public class ForegroundScript : MonoBehaviour 
{
	public ForegroundScript Instance;
	public GameObject [] prefabList;
	
	private float slowSpeed, fastSpeed, velocity;
	private float startPos;
	public bool slow, fast;
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		slowSpeed = 4.0f;
		fastSpeed = 6.0f;
		startPos = 28.0f;
		velocity = 0.25f;
		slow = true;
		fast = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		for(int i = 0; i < prefabList.Length; i++)
		{
			if(prefabList[i].transform.position.x >= -14)
			{
				if(slow)
				{
					prefabList[i].transform.position -= new Vector3(slowSpeed * Time.deltaTime,0,0);
				}
				else if(fast)
				{
					
					prefabList[i].transform.position -= new Vector3(fastSpeed * Time.deltaTime,0,0);
				}
			}
			else
			{
				if(i == 0)
				{
					prefabList[i].transform.position = new Vector3(prefabList[2].transform.position.x + 13.9f, 0 ,1);
				}
				else
				{
					prefabList[i].transform.position = new Vector3(prefabList[i - 1].transform.position.x + 14,0,1);
				}
			}
		}
	
	}
}
