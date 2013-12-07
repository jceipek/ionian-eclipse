using UnityEngine;
using System.Collections;

public class ShadowAttackAbility : MonoBehaviour
{
	public Transform[] m_endPoints = new Transform[2];
	public float m_damage = 30;
	public float m_force = 0;

	public void Attack ()
	{
		var linecastHits = Physics2D.LinecastAll (m_endPoints [0].position, m_endPoints [1].position);
		foreach (var hit in linecastHits) {
			if (hit.collider) {
				GameObject hitObject = hit.collider.gameObject;

				// don't kill your own ship
				if (hitObject == m_endPoints [0].gameObject || hitObject == m_endPoints [1].gameObject) {
					return;
				}

				BulletHit bulletHit = hitObject.GetComponent<BulletHit> ();
				if (bulletHit) {
					bulletHit.GetHit (m_damage, transform.up * m_force);
				}
			}
		}
	}
}
