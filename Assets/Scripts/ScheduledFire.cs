using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FireAbility))]
public class ScheduledFire : MonoBehaviour
{

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
			yield return new WaitForSeconds (0.2f);
			m_fireAbility.Fire ();
		}
	}
}
