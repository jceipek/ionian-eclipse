using UnityEngine;
using System.Collections;

public class KineticallySusceptible : MonoBehaviour
{	
		private Rigidbody2D m_rigidbody;

		void OnEnable ()
		{
				m_rigidbody = GetComponent<Rigidbody2D> ();
		}

		public void GetHit (Vector3 force)
		{
				if (m_rigidbody) {
						m_rigidbody.AddForce (force);
				}
		}
}