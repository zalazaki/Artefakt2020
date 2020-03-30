using UnityEngine;
using System.Collections;

public class AudioStationaryNPC : MonoBehaviour
{
	public FMODUnity.StudioEventEmitter turretRotation;

	/*[FMODUnity.EventRef]
	public string turretShootEvent;
	FMOD.Studio.EventInstance turretShoot;*/

	//private Sentry turret;

	/*void Start()
	{
		sentry = GetComponent<Sentry> ():
			turretRotation = FMODUnity.RuntimeManager.CreateInstance ()
	}*/

	public void AudioStationaryNPCActivate()
	{
		Debug.Log ("StationaryNPCActivated");
	}

	public void AudioStationaryNPCDeactivate()
	{
		Debug.Log ("StationaryNPCDeactivated");
	}

	public void AudioStationaryNPCShoot()
	{
		//FMODUnity.RuntimeManager.PlayOneShot (turretShoot, transform.position);

		/*turretShoot = FMODUnity.RuntimeManager.CreateInstance (turretShootEvent);
		FMODUnity.RuntimeManager.AttachInstanceToGameObject (turretShoot, turret.muzzleTransform, GetComponent<Rigidbody>());
		turretShoot.start ();*/

		Debug.Log ("StationaryNPCShoot");
	}

	public void AudioStationaryNPCRotationStart()
	{
		turretRotation.SetParameter ("rotationcheck", 0f);
		turretRotation.Play ();
		Debug.Log ("StationaryNPCRotationStarted");
	}

	public void AudioStationaryNPCRotationStop()
	{
		turretRotation.SetParameter ("rotationcheck", 1f);
		Debug.Log ("StationaryNPCRotationStopped");
	}

	public void AudioStationaryNPCDie()
	{
		turretRotation.Stop ();
		Debug.Log("StationaryNPCDied");

	}
}
