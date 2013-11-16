using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class HealthVisualizer : MonoBehaviour
{
	public SpriteRenderer m_sheild;
	private Health m_health;
	public Color startColor = Color.green;
	public Color endColor = new Color (0.1F, 0.8F, 0.1F, 0.5F);
	public Color lerpedColor = Color.white;


	void OnEnable ()
	{
		m_health = GetComponent<Health> ();
				
	}

	// Update is called once per frame
	void Update ()
	{
		//Returns a float of value between 0 to 1000
		//3rd argument only accepts values between 0 to 1 
		lerpedColor = Color.Lerp (endColor, startColor, m_health.GetHealthRatio ());
		m_sheild.color = lerpedColor;
	
	}
}
