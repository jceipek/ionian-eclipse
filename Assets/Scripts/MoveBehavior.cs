using UnityEngine;
using System.Collections;

public class MoveBehavior : MonoBehaviour
{
	public float m_maxSpeed = 20;
	public float m_acceleration = 600;
	private Rigidbody2D m_rigidbody;
	
	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void Move (float horizontal, float vertical)
	{
		Vector3 movementForce = (new Vector3 (horizontal, vertical, 0)) * m_acceleration;
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
	}
}
