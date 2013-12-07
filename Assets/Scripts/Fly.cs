using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{
		private float m_speed = 10f;
		private float m_force = 1000f;
		private float m_damage = 1f;
		private Vector3 m_previousPosition;
		private RaycastHit2D[] m_linecastResults = new RaycastHit2D[1]; // For efficient caching
		private SpriteRenderer m_spriteRenderer;

		void OnEnable ()
		{
				m_spriteRenderer = GetComponent<SpriteRenderer> ();
		}

		public void Init (Color color, float speed = 10f, float force = 1000f, float damage = 1f)
		{
				m_spriteRenderer.color = color;
				m_speed = speed;
				m_force = force;
				m_damage = damage;
				StartCoroutine (Die (10f));
				m_previousPosition = transform.position;
		}

		IEnumerator Die (float seconds)
		{
				yield return new WaitForSeconds (seconds);
				Destroy (gameObject);
		}

		void Reflect ()
		{
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.position = m_previousPosition;
		}

		void FixedUpdate ()
		{
				int hitCount = Physics2D.LinecastNonAlloc (m_previousPosition, transform.position + transform.up * (Time.fixedDeltaTime * m_speed), m_linecastResults);
				for (int i = 0; i < hitCount; i++) {
						RaycastHit2D hit = m_linecastResults [i];
						if (hit.collider) {
								var hitMaterial = hit.collider.sharedMaterial;
								if (hit.collider.sharedMaterial && hitMaterial.name == "Deflect") {
										Reflect ();
										return;
								}

								GameObject hitObject = hit.collider.gameObject;
								KineticallySusceptible kineticallySusceptible = hitObject.GetComponent<KineticallySusceptible> ();
								EnergeticallySusceptible bulletHit = hitObject.GetComponent<EnergeticallySusceptible> ();
								if (kineticallySusceptible) {
										kineticallySusceptible.GetHit (transform.up * m_force);
								}
								if (bulletHit) {
										bulletHit.GetHit (m_damage);
										Destroy (gameObject);
								}
						}
				}

				transform.position += transform.up * Time.fixedDeltaTime * m_speed;
				m_previousPosition = transform.position;
		}
}
