using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveBehavior))]

public class gameController : MonoBehaviour
{
	public string[] shootAxis = new string[2];
	public string[] moveAxis = new string[2];
	public float m_torqueForce;
	private Rigidbody2D m_rigidbody;
	private MoveBehavior m_moveBehavior;

	// Use this for initialization
	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
		m_moveBehavior = GetComponent<MoveBehavior> ();

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
		float horizontal = Input.GetAxis (moveAxis [0]);
		float vertical = Input.GetAxis (moveAxis [1]);

		float lookHorizontal = Input.GetAxis (shootAxis [0]);
		float lookVertical = Input.GetAxis (shootAxis [1]);

		m_moveBehavior.Move (horizontal, -vertical);

		m_rigidbody.AddTorque (GetTorque (transform.up, (new Vector3 (lookHorizontal, -lookVertical)).normalized));
	}
}