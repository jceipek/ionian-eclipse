using UnityEngine;
using System.Collections;

public class GravityWellBehavior : MonoBehaviour
{
		public float m_force = 1000f;	
		public float m_radius = 6f;
		public float m_secondsToImplode = 10f;
		public GameObject m_visualRadius;
		private Collider2D[] m_overlapCircleResults = new Collider2D[20];
		private float m_spriteWidth;
		private MineAbility m_gravityWellAbility;

		public void Init (MineAbility mineAbility)
		{
				m_gravityWellAbility = mineAbility;
		}

		void OnEnable ()
		{
				m_spriteWidth = m_visualRadius.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x;
		}

		void Start ()
		{
				StartCoroutine (Pulse (m_secondsToImplode));
		}

		IEnumerator Pulse (float seconds)
		{
				float total = seconds;
				float delta = 0.01f;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						m_visualRadius.transform.localScale = Vector3.one * Mathf.Sin (1 / total * 100f) * m_spriteWidth * 2;
						CheckHit ();
				}

				Explode ();
		}

		void Explode ()
		{
				if (m_gravityWellAbility)
						m_gravityWellAbility.DecrementMineCount ();
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
										var difference = transform.position - unfortunate.transform.position;
										kineticallySusceptible.GetHit (difference.normalized * Mathf.Lerp (m_force, 0f, difference.magnitude / m_radius));
								}
						}
				}
		}
}