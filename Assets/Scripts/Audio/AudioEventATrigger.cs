using UnityEngine;
using System.Collections;

public class AudioEventATrigger : MonoBehaviour
{
	public FMODUnity.StudioEventEmitter waterfallEmitter;

	public void AudioEventATriggered()
	{
		waterfallEmitter.Play ();
	
		Debug.Log("EventATriggered");
	}

}
