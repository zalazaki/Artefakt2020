using UnityEngine;
using System.Collections;

public class AudioMovingNPC : MonoBehaviour
{
	public FMODUnity.StudioEventEmitter movingNPCManager;
	private AudioManager audioManager;

	/*
	[FMODUnity.EventRef]
	public string guardManagerEvent;
	FMOD.Studio.EventInstance guardManager;
	*/

	void Awake()
	{
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
		audioManager.audioMovingNPC = this;
	}

	void update ()
	{
		//Fäster event-instansen vid spelobjektets position och uppdaterar denna vid varje frame
		/*
		guardManager.set3DAttributes (FMODUnity.RuntimeUtils.To3DAttributes (gameObject, GetComponent<Rigidbody> ()));
		*/
	}

	public void MovingNPCSpawned()
	{
		Debug.Log ("MovingNPCSpawned");
	}

	public void MovingNPCHit(int hitpoints)
	{
		Debug.Log("MovingNPCHit - HitpointsRemaining: " + hitpoints);
	}

	public void MovingNPCKilledplayer()
	{
		movingNPCManager.Stop ();
		Debug.Log("MovingNPCKilledplayer");
	}

	public void MovingNPCDied()
	{
		movingNPCManager.SetParameter ("Death", 2f);
		Debug.Log("MovingNPCDied");
	}

}
