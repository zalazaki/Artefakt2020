using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterToggle : MonoBehaviour {

	bool toggle;
	public float trueValue;
	public float falseValue;
	public string parameterName;
	public FMODUnity.StudioEventEmitter studioEmitter;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			toggle = !toggle;
			Debug.Log (toggle);
		}

		if (toggle) 
		{
			studioEmitter.SetParameter (parameterName, trueValue);
		} 

		else 
		{
			studioEmitter.SetParameter (parameterName, falseValue);
		}
	}
}