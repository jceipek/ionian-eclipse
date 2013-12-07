using UnityEngine;
using System.Collections;

public class GravityWellAbility : MonoBehaviour
{

		private GameObject m_gravityWell;
		public float m_rechargeTime = 2f;
		private bool m_canCreateWell = true;
		

		void OnEnable ()
		{
				m_gravityWell = Resources.Load ("GravityWell") as GameObject;
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
				yield return new WaitForSeconds (m_rechargeTime);
				m_canCreateWell = true;
		}
}
