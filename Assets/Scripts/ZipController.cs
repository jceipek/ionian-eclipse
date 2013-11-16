using UnityEngine;
using System.Collections;

public class ZipController : MonoBehaviour
{
		//private MoveToDest m_moveToDest;
		public float m_moveSpeed;
		private Rigidbody2D m_rigidbody;
		// Use this for initialization
		void OnEnable ()
		{
				m_rigidbody = GetComponent<Rigidbody2D> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				float horizontal = Input.GetAxis ("KeyHorizontal");
				float vertical = Input.GetAxis ("KeyVertical");
				m_rigidbody.AddForce ((new Vector3 (horizontal, vertical, 0)) * m_moveSpeed);
				//m_moveToDest.SetDest (transform.position + move);
		}
}