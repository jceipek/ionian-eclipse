using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]

public class CanHeal : MonoBehaviour
{

	private Health m_health;

	void OnEnable ()
	{
		m_health = GetComponent<Health> ();
	}

	public float Heal (float healAmount)
	{
		return m_health.ChangeHealthBy (healAmount);
	}
}
