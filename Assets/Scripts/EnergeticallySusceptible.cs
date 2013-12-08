using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class EnergeticallySusceptible : MonoBehaviour
{	
		private Health m_health;

		void OnEnable ()
		{
				m_health = GetComponent<Health> ();
		}

		public void GetHit (float damage)
		{
				m_health.ChangeHealthBy (-damage);
		}
}