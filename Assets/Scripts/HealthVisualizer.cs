using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BulletHit))]
public class HealthVisualizer : MonoBehaviour
{
		public SpriteRenderer m_shield;
		private BulletHit m_bulletHit;
		public Color m_startColor = Color.white;
		public Color m_endColor = new Color (0.1F, 0.8F, 0.1F, 0.5F);
		public Vector3 m_minimumShieldSize;
		public Vector3 m_maximumShieldSize;

		void OnEnable ()
		{
				m_bulletHit = GetComponent<BulletHit> ();
		}

		// Update is called once per frame
		void Update ()
		{
				
				if (m_bulletHit.GetHealth () >= m_bulletHit.m_startHealth / 2f) {
						m_shield.transform.localScale = Vector3.Lerp (m_minimumShieldSize, m_maximumShieldSize, m_bulletHit.GetHealthRatio () - 0.5f);

				} else {
						Color lerpedColor = Color.Lerp (m_endColor, m_startColor, m_bulletHit.GetHealthRatio ());
						m_shield.color = lerpedColor;
				}
	
		}
}
