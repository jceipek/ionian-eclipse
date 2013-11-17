using UnityEngine;
using System.Collections;

public class HealingAbility : MonoBehaviour
{

	public float m_healAmount = 10f;

	public void Heal (Collider2D[] healedShips)
	{
		foreach (Collider2D ship in healedShips) {
			CanHeal canHeal = ship.GetComponent<CanHeal> ();
			if (canHeal) {
				canHeal.Heal (m_healAmount);
			}
		}
	}
}
