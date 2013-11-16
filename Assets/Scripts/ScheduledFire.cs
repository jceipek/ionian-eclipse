using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FireAbility))]
public class ScheduledFire : MonoBehaviour
{
	public float m_fireFrequencySeconds;
	private FireAbility m_fireAbility;
	void OnEnable ()
	{
		m_fireAbility = GetComponent<FireAbility> ();
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Fire ());
	}

	IEnumerator Fire ()
	{
		while (true) {
			yield return new WaitForSeconds (m_fireFrequencySeconds);
			m_fireAbility.Fire ();
		}
	}
}
