using UnityEngine;
using System.Collections;

public class AudioPlayerActions : MonoBehaviour
{
	public bool showFootstepDebugMessages = false;

	/*[FMODUnity.EventRef]
	public string playerShoot;*/

	//Skapar referens till FMOD-eventets sökväg
	[FMODUnity.EventRef]
	public string playerFootstepEvent;

	//Deklarerar en instans av ett FMOD-event
	FMOD.Studio.EventInstance playerFootstep;

	[FMODUnity.EventRef]
	public string playerLandEvent;
	FMOD.Studio.EventInstance playerLand;

	[FMODUnity.EventRef]
	public string playerJumpEvent;
	FMOD.Studio.EventInstance playerJump;

	[FMODUnity.EventRef]
	public string playerSpawnEvent;
	FMOD.Studio.EventInstance playerSpawn;

	[FMODUnity.EventRef]
	public string playerShootFireEvent;
	FMOD.Studio.EventInstance playerShootFire;

	[FMODUnity.EventRef]
	public string playerShootIceEvent;
	FMOD.Studio.EventInstance playerShootIce;

	[FMODUnity.EventRef]
	public string playerDiedEvent;
	FMOD.Studio.EventInstance playerDied;

	public PickupManager pickupManager;

	public void PlayFootstep(int material)
	{
		//Skapar och kopplar samman eventets sökväg till instansen
		playerFootstep = FMODUnity.RuntimeManager.CreateInstance (playerFootstepEvent);

		
		//Startar instansen
		playerFootstep.start ();

		if (!showFootstepDebugMessages)
		{
			return;
		}
	}
		
	public void PlayLand (int material)
	{
		playerLand = FMODUnity.RuntimeManager.CreateInstance (playerLandEvent);
		switch (material) 
		{
		case 1:
			playerLand.setParameterValue ("Surface", 0f);
			break;
		case 2:
			playerLand.setParameterValue ("Surface", 1f);
			break;
		case 3:
			playerLand.setParameterValue ("Surface", 2f);
			break;
		case 4:
			playerLand.setParameterValue ("Surface", 3f);
			break;
		}
		playerLand.start ();
		Debug.Log ("PlayerLanded - Material: " + material);
	}
		
	public void PlayJump (int material)
	{
		playerJump = FMODUnity.RuntimeManager.CreateInstance (playerJumpEvent);
		playerJump.start ();	
		Debug.Log ("PlayerJumped - Material: " + material);
	}

	public void PlaySpawn()
	{
		playerSpawn = FMODUnity.RuntimeManager.CreateInstance (playerSpawnEvent);
		playerSpawn.start ();
		Debug.Log ("PlayerSpawned");
	}

	public void PlayShoot()
	{
		if (pickupManager.numberOfPickups <=2) 
		{
			playerShootFire = FMODUnity.RuntimeManager.CreateInstance (playerShootFireEvent);
            playerShootFire.start();
        }

        else if (pickupManager.numberOfPickups >=3)
        {
            playerShootIce = FMODUnity.RuntimeManager.CreateInstance (playerShootIceEvent);
            playerShootIce.start();
        }
		
		Debug.Log ("PlayerShoot");
	}

	public void PlayerDied()
	{
		playerDied = FMODUnity.RuntimeManager.CreateInstance (playerDiedEvent);
		playerDied.start ();
		Debug.Log ("PlayerDied");
	}

	public void PlayerWon(float waitTime)
	{
		Debug.Log ("PlayerWon - Waiting " + waitTime + " seconds");
	}
}

