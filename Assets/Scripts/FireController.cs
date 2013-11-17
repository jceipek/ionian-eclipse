using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FireAbility))]
public class FireController : MonoBehaviour
{

	public string m_fireButton;
	public bool m_fireButtonIsAxis;
	private FireAbility m_fireAbility;


	void OnEnable ()
	{
		m_fireAbility = GetComponent<FireAbility> ();
	}

	// Update is called once per frame
	void Update ()
	{
		bool fireButton = !m_fireButtonIsAxis && Input.GetButtonDown (m_fireButton);
		bool fireAxis = m_fireButtonIsAxis && (Input.GetAxis (m_fireButton) > 0.1f);
		if (fireButton || fireAxis) {
			m_fireAbility.Fire ();
		}
	}
}
