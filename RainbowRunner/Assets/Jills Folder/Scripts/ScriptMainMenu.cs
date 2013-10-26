using UnityEngine;
using System.Collections;

public class ScriptMainMenu : MonoBehaviour {
	
	private RaycastHit hit = new RaycastHit();
	private Ray ray = new Ray();

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
			if(Physics.Raycast(ray, out hit, 10.0f))
			{
				if(hit.collider.transform.tag == "StartButton")
				{
					Debug.Log("Start Clicked");	
				}
				else if(hit.collider.transform.tag == "ExitButton")
				{
					Debug.Log("Exit Clicked");	
				}
			}
		}
	}

}
