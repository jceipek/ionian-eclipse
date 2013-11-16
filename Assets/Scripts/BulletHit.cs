using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	public float m_health = 100f;
	
	private Rigidbody2D m_rigidbody;


	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void GetHit (float damage, Vector3 force)
	{
		m_rigidbody.AddForce (force);

		m_health -= damage;
		if (m_health <= 0) {
			Destroy (gameObject);
		}
	}
}