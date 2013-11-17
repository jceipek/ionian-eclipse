using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]

public class BulletHit : MonoBehaviour
{	
	private Health m_health;
	private Rigidbody2D m_rigidbody;

	void OnEnable ()
	{
		m_health = GetComponent<Health> ();
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void GetHit (float damage, Vector3 force)
	{
		m_rigidbody.AddForce (force);
		m_health.ChangeHealthBy (-damage);
	}
}