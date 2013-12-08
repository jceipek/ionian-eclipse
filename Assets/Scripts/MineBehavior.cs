using UnityEngine;
using System.Collections;

public class MineBehavior : MonoBehaviour
{
		public float m_force = 1000f;	
		public float m_damage = 30f;
		public float m_radius = 6f;
		public float m_secondsToExplode = 2f;
		public GameObject m_visualRadius;
		private Collider2D[] m_overlapCircleResults = new Collider2D[20];
		private float m_spriteWidth;
		private MineAbility m_mineAbility;

		public void Init (MineAbility mineAbility)
		{
				m_mineAbility = mineAbility;
		}

		void OnEnable ()
		{
				m_spriteWidth = m_visualRadius.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x;
		}

		void Start ()
		{
				StartCoroutine (Pulse (m_secondsToExplode));
		}

		IEnumerator Pulse (float seconds)
		{
				float total = seconds;
				float delta = 0.01f;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						m_visualRadius.transform.localScale = Vector3.one * Mathf.Sin (1 / total * 10f);
				}

				StartCoroutine (Explode (0.1f));
		}

		IEnumerator Explode (float seconds)
		{
				float total = seconds;
				float delta = 0.01f;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						m_visualRadius.transform.localScale = Vector3.Lerp (Vector3.one * m_radius / m_spriteWidth, Vector3.zero, total / seconds);
				}

				CheckHit ();
				if (m_mineAbility)
						m_mineAbility.DecrementMineCount ();
				Destroy (gameObject);
		}

		void CheckHit ()
		{
				int hitCount = Physics2D.OverlapCircleNonAlloc ((Vector2)transform.position, m_radius, m_overlapCircleResults);
				for (var i = 0; i < hitCount; i++) {
						Collider2D unfortunate = m_overlapCircleResults [i];
						if (unfortunate) {
								KineticallySusceptible kineticallySusceptible = unfortunate.GetComponent<KineticallySusceptible> ();
								if (kineticallySusceptible) {
										kineticallySusceptible.GetHit ((transform.position - unfortunate.transform.position) * -m_force);
								}
								EnergeticallySusceptible bulletHit = unfortunate.GetComponent<EnergeticallySusceptible> ();
								if (bulletHit) {
										bulletHit.GetHit (m_damage);
								}
						}
				}
		}
}