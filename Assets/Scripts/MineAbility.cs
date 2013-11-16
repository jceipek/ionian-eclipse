using UnityEngine;
using System.Collections;

public class MineAbility : MonoBehaviour
{
		public Transform[] m_minePos;
		private GameObject m_mine;
	
		void OnEnable ()
		{
				m_mine = Resources.Load ("Mine") as GameObject;
		}
	
		public void Fire ()
		{
				foreach (var mineTransform in m_minePos) {
						Instantiate (m_mine, mineTransform.position, transform.rotation);
				}
		}
}
