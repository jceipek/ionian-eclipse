using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveToDest))]
public class gameController : MonoBehaviour
{
	public MoveToDest m_moveToDest;

	public Vector3 pos;

	// Use this for initialization
	void OnEnable ()
	{
		m_moveToDest = GetComponent<MoveToDest> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis ("L_XAxis_1");
		float vertical = Input.GetAxis ("L_YAxis_1");


		m_moveToDest.SetDest (transform.position + new Vector3 (horizontal, -vertical, 0));
	}
}