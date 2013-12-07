using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveBehavior))]

public class MultilineController : MonoBehaviour
{
	public string[] m_controlAxis = new string[2];
	private Rigidbody2D m_rigidbody;
	private MoveBehavior m_moveBehavior;

	// Use this for initialization
	void OnEnable ()
	{
		m_rigidbody = GetComponent<Rigidbody2D> ();
		m_moveBehavior = GetComponent<MoveBehavior> ();

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis (m_controlAxis [0]);
		float vertical = Input.GetAxis (m_controlAxis [1]);
		
		//float lookHorizontal = Input.GetAxis ("R_XAxis_1");
		//float lookVertical = Input.GetAxis ("R_YAxis_1");

		m_moveBehavior.Move (horizontal, -vertical);
		
		//m_rigidbody.AddTorque (GetTorque (transform.up, (new Vector3 (lookVertical, -lookHorizontal)).normalized));

		//"L_YAxis_1"
	}
}