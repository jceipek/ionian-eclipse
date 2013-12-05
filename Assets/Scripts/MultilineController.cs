using UnityEngine;
using System.Collections;

public class MultilineController : MonoBehaviour
{
	public float m_moveSpeed;
	public string[] m_controlAxis = new string[2];
	private Rigidbody2D m_rigidbody;
	
	// Use this for initialization
	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis (m_controlAxis [0]);
		float vertical = Input.GetAxis (m_controlAxis [1]);
		
		//float lookHorizontal = Input.GetAxis ("R_XAxis_1");
		//float lookVertical = Input.GetAxis ("R_YAxis_1");
		
		m_rigidbody.AddForce ((new Vector3 (horizontal, -vertical, 0)) * m_moveSpeed);
		
		//m_rigidbody.AddTorque (GetTorque (transform.up, (new Vector3 (lookVertical, -lookHorizontal)).normalized));

		//"L_YAxis_1"
	}
}