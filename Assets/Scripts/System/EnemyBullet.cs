using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour 
{
	public float initialVelocity = 10;
	public float lifeTime = 3;
	public bool onCollisionDestroy = false;
	private Sentry sentryRef;

	void Awake()
	{
		sentryRef = GetComponentInParent<Sentry> ();
		transform.rotation = sentryRef.muzzleTransform.rotation;
		GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity;
		Destroy(gameObject, lifeTime);
	}


	void OnCollisionEnter(Collision collision)
	{
		collision.collider.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);

		if(onCollisionDestroy)
		{
			Destroy(gameObject);
		}
	}
}
