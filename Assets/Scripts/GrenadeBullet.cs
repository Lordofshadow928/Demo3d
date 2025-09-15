using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
	public GameObject explosionPrefab;
	public float explosionRadius;
	public float explosionForce;
	public int damage;

	private void OnCollisionEnter(Collision collision)
	{
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy(gameObject);
		BlowObject();
	}

	private void BlowObject()
	{
		Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
		for(int i = 0; i < affectedObjects.Length; i++)
		{
			DealDamage(affectedObjects[i]);
			AddForceToObject(affectedObjects[i]);
        }
	}

	private void DealDamage(Collider victim)
	{
		Health health = victim.GetComponent<Health>();
		if(health != null)
		{
			health.TakeDamage(damage);
        }
    }

	private void AddForceToObject(Collider affectedObject)
	{
		Rigidbody rb = affectedObject.attachedRigidbody;
		if(rb)
		{
			rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
}
