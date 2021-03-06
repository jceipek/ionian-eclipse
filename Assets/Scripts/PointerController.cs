﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(HealingAbility))]
[RequireComponent (typeof(SlowdownAbility))]
[RequireComponent (typeof(GravityWellAbility))]

public class PointerController : MonoBehaviour
{
		private HealingAbility m_healingAbility;
		private SlowdownAbility m_slowdownAbility;
		private GravityWellAbility m_gravityWellAbility;

		public float abilityRadius = 3f;
		public string m_healingButton = "Heal";
		public string m_slowdownButton = "Slowdown";
		public string m_gravityWellButton = "Gravity Well";

		void OnEnable ()
		{
				m_healingAbility = GetComponent<HealingAbility> ();
				m_slowdownAbility = GetComponent<SlowdownAbility> ();
				m_gravityWellAbility = GetComponent<GravityWellAbility> ();
		}
	
		void Update ()
		{
				Vector2 mousePosition = (Camera.main.ScreenPointToRay (Input.mousePosition)).origin;

				// Heal friends within a radius of your mouse, if you click the heal button
				if (Input.GetButtonDown (m_healingButton)) {
						Collider2D[] friends = GetFriendsNearLocation (mousePosition);
						m_healingAbility.Heal (friends);
				}

				// Slow down ships within a radius of your mouse, if you click the slowdown button
				if (Input.GetButtonDown (m_slowdownButton)) {
						Collider2D[] ships = GetEverythingNearLocation (mousePosition);
						m_slowdownAbility.Slowdown (ships);
				}

				// Add a gravity well within a radius of your mouse, if you click the gravity well button
				if (Input.GetButtonDown (m_gravityWellButton)) {
						m_gravityWellAbility.MakeWell (mousePosition);
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
