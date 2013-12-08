using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveBehavior))]

public class ZipController : MonoBehaviour
{
		//private MoveToDest m_moveToDest;
		private MoveBehavior m_moveBehavior;

		void OnEnable ()
		{
				m_moveBehavior = GetComponent<MoveBehavior> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				float horizontal = Input.GetAxis ("KeyHorizontal");
				float vertical = Input.GetAxis ("KeyVertical");
				m_moveBehavior.Move (horizontal, vertical);
				//m_moveToDest.SetDest (transform.position + move);
		}
}