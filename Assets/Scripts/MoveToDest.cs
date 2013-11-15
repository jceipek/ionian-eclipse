using UnityEngine;
using System.Collections;

public class MoveToDest : MonoBehaviour
{
	public float m_accelSpeed;
	public float m_drag;
	public Vector2 m_destination;
	public Vector2 m_accel;
	public Vector2 m_velocity;

	public Rigidbody2D m_rigidbody;


	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void SetDest (Vector2 dest)
	{
		m_destination = dest;
	}

	void Move ()
	{
//		Vector3 vel;
		Vector3 dest = m_destination;
//		Vector3 diff = (dest - transform.position);
//
//		m_accel = diff.normalized * m_accelSpeed;

	


		float k = 6;
		Vector3 vec = dest - transform.position;
//		bool adjust_angle = vec.normalized > 0.2f;
			
		vec = vec.normalized * k;
		//ship.m_linearDamping = 3;
		//ship.m_angularDamping = 60;
		//float des_angle = Mathf.Atan2 (vec.x, -vec.y);
		//float next_angle = (ship.GetAngle () + ship.GetAngularVelocity ()) / 3;
		//var total_rotation = des_angle - next_angle;
		//ship.ApplyTorque (total_rotation < 0 ? -10 : 10);
		//if (adjust_angle) {
		//	ship.SetAngle (des_angle);
		m_rigidbody.AddForce (vec * 10f);
		//	}


//		// TODO: Make this better
//		if (diff.magnitude > 0.5f) {
		transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 ((dest.y - transform.position.y), (dest.x - transform.position.x)) * Mathf.Rad2Deg - 90);
//		}
	}

	void FixedUpdate ()
	{
		Move ();
	}
}