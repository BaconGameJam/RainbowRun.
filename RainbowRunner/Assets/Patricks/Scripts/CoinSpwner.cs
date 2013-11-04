using UnityEngine;
using System.Collections;

public class CoinSpwner : MonoBehaviour {
	public int currentCount, maxCount;
	public GameObject goldcoin, parentObject;
	private GameObject [] clones;
	// Use this for initialization
	void Start () 	
	{
		maxCount = 10;
		clones = new GameObject[maxCount];
		for(int i  = 0; currentCount < maxCount; i++)
		{
			clones[i] = Instantiate(goldcoin)as GameObject;
			//clones[i].transform.parent = parentObject;
			currentCount++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
