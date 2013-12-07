using UnityEngine;
using System.Collections;

public class ShadowAttackAbility : MonoBehaviour
{
		public Transform[] m_endPoints = new Transform[2];
		public float m_damage = 30;
		public float m_lineFlashDuration = 0.1f;
		public float m_lineFlashWidth = 0.2f;


		private LineRenderer m_lineRenderer;

		void OnEnable ()
		{
				m_lineRenderer = GetComponent<LineRenderer> ();
		}

		public void Attack ()
		{
				StartCoroutine (Flash ());
				var linecastHits = Physics2D.LinecastAll (m_endPoints [0].position, m_endPoints [1].position);
				foreach (var hit in linecastHits) {
						if (hit.collider) {
								GameObject hitObject = hit.collider.gameObject;

								// don't kill your own ship
								if (hitObject == m_endPoints [0].gameObject || hitObject == m_endPoints [1].gameObject) {
										return;
								}

								EnergeticallySusceptible energeticallySusceptible = hitObject.GetComponent<EnergeticallySusceptible> ();
								if (energeticallySusceptible) {
										energeticallySusceptible.GetHit (m_damage);
								}
						}
				}
		}

		private IEnumerator Flash ()
		{
				m_lineRenderer.SetWidth (m_lineFlashWidth, m_lineFlashWidth);
				yield return new WaitForSeconds (m_lineFlashDuration);
				m_lineRenderer.SetWidth (0f, 0f);

		}
	
}
