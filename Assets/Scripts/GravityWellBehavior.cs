using UnityEngine;
using System.Collections;

public class GravityWellBehavior : MonoBehaviour
{
		public float m_force = 1000f;	
		public float m_initialRadius = 6f;
		public float m_secondsToImplode = 10f;
		public GameObject m_visualRadius;
		private Collider2D[] m_overlapCircleResults = new Collider2D[20];
		private float m_spriteWidth;
		private GravityWellAbility m_gravityWellAbility;
		private float m_radius;

		public void Init (GravityWellAbility gravityWellAbility)
		{
				m_gravityWellAbility = gravityWellAbility;
		}

		void OnEnable ()
		{
				m_spriteWidth = m_visualRadius.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x;
		}

		void Start ()
		{
				m_radius = m_initialRadius;
				StartCoroutine (Pulse (m_secondsToImplode));
				m_visualRadius.transform.localScale = Vector3.one * m_initialRadius / m_spriteWidth;
		}

		IEnumerator Pulse (float seconds)
		{
				float total = seconds;
				float delta = 0.01f;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						m_radius = Mathf.Lerp (0, m_initialRadius / m_spriteWidth, total / seconds);
						m_visualRadius.transform.localScale = m_radius * Vector3.one;//Vector3.one * Mathf.Sin (1 / total * 100f) * m_initialRadius / m_spriteWidth;
						CheckHit ();
				}

				Explode ();
		}

		void Explode ()
		{
				Destroy (gameObject);
		}

		void CheckHit ()
		{
				int hitCount = Physics2D.OverlapCircleNonAlloc ((Vector2)transform.position, m_initialRadius, m_overlapCircleResults);
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