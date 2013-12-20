using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FireAbility))]
public class FireController : MonoBehaviour
{
		public string[] shootAxis = new string[2];
		private FireAbility m_fireAbility;


		void OnEnable ()
		{
				m_fireAbility = GetComponent<FireAbility> ();
		}

		// Update is called once per frame
		void Update ()
		{
				float horizontal = Input.GetAxis (shootAxis [0]);
				float vertical = Input.GetAxis (shootAxis [1]);
				var direction = new Vector3 (horizontal, vertical, 0);
				if (direction.magnitude > 0.1f) {
						m_fireAbility.Fire (direction: direction.normalized);
				}
		}
}
