using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{
	public float m_moveSpeed;
	public float m_torqueForce;
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

		m_rigidbody.AddForce ((new Vector3 (horizontal, -vertical, 0)) * m_moveSpeed);

		m_rigidbody.AddTorque (GetTorque (transform.up, (new Vector3 (lookHorizontal, -lookVertical)).normalized));
	}
}