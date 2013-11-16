using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MineAbility))]
public class MineController : MonoBehaviour
{
	
		public string m_mineButton;
		public bool m_mineButtonIsAxis;
		private MineAbility m_mineAbility;
	
		void OnEnable ()
		{
				m_mineAbility = GetComponent<MineAbility> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				bool mineButton = !m_mineButtonIsAxis && Input.GetButtonDown (m_mineButton);
				bool mineAxis = m_mineButtonIsAxis && (Input.GetAxis (m_mineButton) > 0.1f);
				if (mineButton || mineAxis) {
						m_mineAbility.Fire ();
				}
		}
}