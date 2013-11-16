using UnityEngine;
using System.Collections;

public class HealingAbility : MonoBehaviour
{

	public float m_healAmount = 10f;

	public void Heal (Collider2D[] healedShips, int numShips)
	{
		for (var i = 0; i < numShips; i++) {
			Collider2D healedShip = healedShips [i];
			CanHeal canHeal = healedShip.GetComponent<CanHeal> ();
			if (canHeal) {
				canHeal.Heal (m_healAmount);
			}
		}
	}
}
