using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RadialIndicator))]
public class GravityWellAbility : MonoBehaviour
{

		private GameObject m_gravityWell;
		public float m_rechargeTime = 2f;
		private bool m_canCreateWell = true;
		private RadialIndicator m_visualCooldownIndicator;

		void OnEnable ()
		{
				m_gravityWell = Resources.Load ("GravityWell") as GameObject;
				m_visualCooldownIndicator = GetComponent<RadialIndicator> ();
		}

		public void MakeWell (Vector2 position)
		{
				if (!m_canCreateWell) {
						return;
				}
				Instantiate (m_gravityWell, position, Quaternion.identity);
				m_canCreateWell = false;
				StartCoroutine (CoolDown ());
		}

		private IEnumerator CoolDown ()
		{
				float total = m_rechargeTime;
				float delta = Time.deltaTime;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						m_visualCooldownIndicator.UpdateCooldownIndicator (0, total / m_rechargeTime);
				}
				m_canCreateWell = true;
		}
}
