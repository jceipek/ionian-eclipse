using UnityEngine;
using System.Collections;

public class MoveToDest : MonoBehaviour
{
	public Vector2 m_destination;
	public float m_torqueContant = 5f;
	public float m_movementConstant = 60f;
	public Rigidbody2D m_rigidbody;


	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void SetDest (Vector2 dest)
	{
		m_destination = dest;
	}
	

	private float GetTorque(Vector3 fwd, Vector3 targetDir) {
		var angle = Vector3.Angle(fwd, targetDir);
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		int direction = (int)perp.normalized.z;
		return m_torqueContant * angle * direction;
	}

	void Move ()
	{
//		Vector3 vel;
		Vector3 dest = m_destination;
//		Vector3 diff = (dest - transform.position);
//		m_accel = diff.normalized * m_accelSpeed;

		Vector3 vec = dest - transform.position;
		float distance = vec.magnitude;
		float torque = GetTorque(transform.up, vec.normalized);
		m_rigidbody.AddForce (vec.normalized * m_movementConstant);

		if (distance > 1.9) {
			m_rigidbody.AddTorque (torque);
		}
	}

	void FixedUpdate ()
	{
		Move ();
	}
}