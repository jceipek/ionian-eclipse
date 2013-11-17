using UnityEngine;
using System.Collections;

public class HealingAbility : MonoBehaviour
{
	private GameObject m_healRayPrefab;
	public float m_healAmount = 10f;

	void OnEnable ()
	{
		m_healRayPrefab = Resources.Load ("HealRay") as GameObject;
	}


	public void Heal (Collider2D[] healedShips)
	{
		foreach (Collider2D ship in healedShips) {
			CanHeal canHeal = ship.GetComponent<CanHeal> ();
			if (canHeal) {
				canHeal.Heal (m_healAmount);
				GameObject healRay = Instantiate (m_healRayPrefab) as GameObject;
				HealRay healRayComponent = healRay.GetComponent<HealRay> ();
				healRayComponent.SetPosition (transform, ship.transform);
			}
		}
	}
}
