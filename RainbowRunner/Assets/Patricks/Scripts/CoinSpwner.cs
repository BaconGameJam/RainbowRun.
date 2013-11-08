using UnityEngine;
using System.Collections;

public class CoinSpwner : MonoBehaviour {
	public static CoinSpwner Instance;
	public GoldCoin coinScript;
	public GameObject goldcoin;
	private GameObject [] clones;
	
	public bool fast, slow, prevFast, prevSlow;
	public int currentCount, maxCount;
	
	// Use this for initialization
	void Start () 	
	{
		maxCount = 10;
		clones = new GameObject[maxCount];
		for(int i  = 0; currentCount < maxCount; i++)
		{
			clones[i] = Instantiate(goldcoin)as GameObject;
			clones[i].transform.position = new Vector3( 30,0,-1);
			clones[i].transform.parent = this.gameObject.transform;
			currentCount++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
		
	}
}
