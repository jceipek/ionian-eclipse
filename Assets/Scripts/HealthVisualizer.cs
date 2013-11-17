using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class HealthVisualizer : MonoBehaviour
{

	public SpriteRenderer m_shield;
	private Health m_health;
	public Color m_startColor = Color.white;
	public Color m_endColor = new Color (0.1F, 0.8F, 0.1F, 0.5F);
	public Vector3 m_minimumShieldSize;
	public Vector3 m_maximumShieldSize;

	void OnEnable ()
	{
		m_health = GetComponent<Health> ();
		if (!m_health) {
			Debug.Log (gameObject.name);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (m_health.GetHealth () >= m_health.GetStartHealth () / 2f) {
			m_shield.transform.localScale = Vector3.Lerp (m_minimumShieldSize, m_maximumShieldSize, m_health.GetHealthRatio () * 2f - 1f);
		} else {
			Color lerpedColor = Color.Lerp (m_endColor, m_startColor, m_health.GetHealthRatio ());
			m_shield.color = lerpedColor;
		}
	}
}