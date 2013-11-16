using UnityEngine;
using System.Collections;

public class MoveToDest : MonoBehaviour
{
	public Vector2 m_destination;
	public float m_torqueForce;
	public float m_linearForce;
	private Rigidbody2D m_rigidbody;


	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void SetDest (Vector2 dest)
	{
		m_destination = dest;
	}
	

	private float GetTorque (Vector3 fwd, Vector3 targetDir)
	{
		var angle = Vector3.Angle (fwd, targetDir);
		Vector3 perp = Vector3.Cross (fwd, targetDir);
		int direction = (int)perp.normalized.z;
		return m_torqueForce * angle * direction;
	}

	void Move ()
	{
		Vector3 dest = m_destination;

		Vector3 vec = dest - transform.position;
		float torque = GetTorque (transform.up, vec.normalized);

		if (vec.sqrMagnitude > 5f) {
			m_rigidbody.AddForce (vec.normalized * m_linearForce);
		}

		if (vec.magnitude > 1) {
			m_rigidbody.AddTorque (torque);
		}
	}

	void FixedUpdate ()
	{
		Move ();
	}
}