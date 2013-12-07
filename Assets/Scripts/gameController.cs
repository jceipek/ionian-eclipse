using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{
	public float m_acceleration;
	public float m_torqueForce;
	public float m_maxSpeed;
	private Rigidbody2D m_rigidbody;

	// Use this for initialization
	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	private float GetTorque (Vector3 fwd, Vector3 targetDir)
	{
		var angle = Vector3.Angle (fwd, targetDir);
		Vector3 perp = Vector3.Cross (fwd, targetDir);
		int direction = (int)perp.normalized.z;
		return m_torqueForce * angle * direction;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("L_XAxis_1");
		float vertical = Input.GetAxis ("L_YAxis_1");

		float lookHorizontal = Input.GetAxis ("R_XAxis_1");
		float lookVertical = Input.GetAxis ("R_YAxis_1");

		Vector3 movementForce = (new Vector3 (horizontal, -vertical, 0)) * m_acceleration;
		// First find out what your modifier would be if the force
		// direction was in the direction of the current velocity
			
		float straightMultiplier = 1 - (m_rigidbody.velocity.magnitude / m_maxSpeed);
		// This value will be 1 if the rigidbody is moving at 0,
		// and 0 if the rigidbody is moving at maxSpeed.
		
		// Then, find out what the dot product is between the force and the velocity
		float forceDot = Vector3.Dot (m_rigidbody.velocity, movementForce);
		
		// Now, smoothly interpolate between full power and modified power
		// depending on what direction the force is going!
		Vector3 modifiedForce = movementForce * straightMultiplier;
		Vector3 correctForce = Vector3.Lerp (movementForce, modifiedForce, forceDot);


		m_rigidbody.AddForce (correctForce);

		m_rigidbody.AddTorque (GetTorque (transform.up, (new Vector3 (lookHorizontal, -lookVertical)).normalized));
	}
}