using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour 
{

	public int total = 3;
	public int ammo = 5;
	public float time = 1.5f;
	public bool underwater;

	[FMODUnity.EventRef]
	public string underwaterEvent;
	FMOD.Studio.EventInstance underwaterSnapshot;

	void Awake ()
	{
		Debug.Log ("Jag finns");
	}

		// Use this for initialization
	void Start () 
	{
		underwaterSnapshot = FMODUnity.RuntimeManager.CreateInstance (underwaterEvent);
		total = AddStuff (10, 20);
		Debug.Log ("My Total Is: " + total);
		Debug.Log ("Game Start");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			ammo--;
			Debug.Log ("Ammo left: " + ammo);
		}
	}

	int AddStuff (int a, int b)
	{
		int localTotal = a + b;
		return localTotal;
	}

	void Underwater (bool underwaterCheck)
	{
		if (underwater) 
		{
			underwaterSnapshot.start ();
			Debug.Log ("I am underwater");
		} 

		else 
		{
			underwaterSnapshot.stop (FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			Debug.Log ("I am no longer underwater");
		}
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{

			Underwater (underwater = true);
		}
	}

	void OnTriggerExit (Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			Underwater (underwater = false);
		}
	}

}