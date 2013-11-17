using UnityEngine;
using System.Collections;

public class HealingAbility : MonoBehaviour
{
	private GameObject m_healRayPrefab;
	public float m_healAmount = 100f;
	public float m_coolDownTime = 10f;
	private bool m_canHeal = true;

	void OnEnable ()
	{
		m_healRayPrefab = Resources.Load ("HealRay") as GameObject;
	}


	public void Heal (Collider2D[] healedShips)
	{
		// Don't heal if we are on cooldown
		if (!m_canHeal) {
			return;
		}

		// Heal if we aren't on cooldown
		bool didHeal = false;
		foreach (Collider2D ship in healedShips) {
			CanHeal canHeal = ship.GetComponent<CanHeal> ();
			if (canHeal) {
				didHeal = true;
				canHeal.Heal (m_healAmount);
				GameObject healRay = Instantiate (m_healRayPrefab) as GameObject;
				HealRay healRayComponent = healRay.GetComponent<HealRay> ();
				healRayComponent.SetPosition (transform, ship.transform);
			}
		}

		// Start cooldown, if we healed
		if (didHeal) {
			m_canHeal = false;
			StartCoroutine (CoolDown (m_coolDownTime));
		}
	}

	IEnumerator CoolDown (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		m_canHeal = true;
	}
}
