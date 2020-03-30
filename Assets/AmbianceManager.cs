using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceManager : MonoBehaviour {

	public FMODUnity.StudioEventEmitter outdoorEmitter;
	public FMODUnity.StudioEventEmitter indoorSmallEmitter;
	public FMODUnity.StudioEventEmitter indoorLargeEmitter;

	public AudioManager audioManager;
	
	// Update is called once per frame
	void Update () 
	{
		//Outdoor ambiancen stängs av i Indoor Large
		/*if (audioManager.material <= 4 && !outdoorEmitter.IsPlaying()) 
		{
			outdoorEmitter.Play ();
			Debug.Log ("Outdoor_Play");
		}	
		if (audioManager.material >= 4 && outdoorEmitter.IsPlaying ()) 
		{
			outdoorEmitter.Stop ();
			Debug.Log ("Outdoor_Stop");
		}*/

		//Small Cave Ambiance spelas upp i indoor small
		if (audioManager.material == 3 && !indoorSmallEmitter.IsPlaying ()) 
		{
			indoorSmallEmitter.Play ();
			Debug.Log ("IndoorSmall_Play");
		}
		if (audioManager.material != 3 && indoorSmallEmitter.IsPlaying ()) 
		{
			indoorSmallEmitter.Stop ();
			Debug.Log ("IndoorSmall_Stop");
		}

		if (audioManager.material == 4 && !indoorLargeEmitter.IsPlaying ()) 
		{
			indoorLargeEmitter.Play ();
			Debug.Log ("IndoorLarge_Play");
		}
		if (audioManager.material != 4 && indoorLargeEmitter.IsPlaying ()) 
		{
			indoorLargeEmitter.Stop ();
			Debug.Log ("IndoorLarge_Stop");
		}
	}
}
