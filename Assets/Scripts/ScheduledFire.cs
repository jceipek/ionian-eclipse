using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FireAbility))]
public class ScheduledFire : MonoBehaviour
{
	public float m_fireFrequencySeconds;
	public float m_lookaheadDistance = 1.0f;
	private FireAbility m_fireAbility;
	private RaycastHit2D[] m_linecastResults = new RaycastHit2D[1]; // For efficient caching

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
		bool enemyInTheWay = false;
		int hit;
				
		while (true) {	
			yield return new WaitForSeconds (m_fireFrequencySeconds);
			hit = Physics2D.LinecastNonAlloc (transform.position + transform.up * m_lookaheadDistance, transform.position + transform.up * 10f, m_linecastResults);
			if (hit > 0) {
				enemyInTheWay = m_linecastResults [0].collider.CompareTag ("Enemy");							
				if (!enemyInTheWay) {
					m_fireAbility.Fire ();
				}
			} else {
				m_fireAbility.Fire ();
			}
			m_fireAbility.Fire ();
		}
	}
}
