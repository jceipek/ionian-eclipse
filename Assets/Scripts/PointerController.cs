using UnityEngine;
using System.Collections;

[RequireComponent (typeof(HealingAbility))]
[RequireComponent (typeof(SlowdownAbility))]

public class PointerController : MonoBehaviour
{
	private HealingAbility m_healingAbility;
	private SlowdownAbility m_slowdownAbility;

	public float abilityRadius = 3f;
	public string m_healingButton = "Heal";
	public string m_slowdownButton = "Slowdown";

	void OnEnable ()
	{
		m_healingAbility = GetComponent<HealingAbility> ();
		m_slowdownAbility = GetComponent<SlowdownAbility> ();
	}
	
	void Update ()
	{

		// Heal friends within a radius of your mouse, if you click the heal button
		if (Input.GetButtonDown (m_healingButton)) {
			Collider2D[] friends = GetFriendsNearLocation ((Vector2)Input.mousePosition);
			m_healingAbility.Heal (friends);
		}

		// Slow down ships within a radius of your mouse, if you click the slowdown button
		if (Input.GetButtonDown (m_slowdownButton)) {
			Collider2D[] ships = GetEverythingNearLocation ((Vector2)Input.mousePosition);
			m_slowdownAbility.Slowdown (ships);
		}
	}

	Collider2D[] GetFriendsNearLocation (Vector2 location)
	{
		return GetEverythingNearLocation (location);
	}

	Collider2D[] GetEnemiesNearLocation (Vector2 location)
	{
		return GetEverythingNearLocation (location);
	}

	Collider2D[] GetEverythingNearLocation (Vector2 location)
	{
		return Physics2D.OverlapCircleAll (location, abilityRadius);
	}
	
}
