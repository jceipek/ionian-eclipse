﻿using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Health))]
public class RespawnController : MonoBehaviour
{
	public float m_respawnTime;

	public void Respawn (string shipName)
	{
		//Wait some time
		StartCoroutine (RespawnInTime (shipName));
		//Debug.Log ("Respawning");
				
	}
	IEnumerator RespawnInTime (string shipName)
	{
		yield return new WaitForSeconds (m_respawnTime); 
		GameObject newShip = Instantiate (Resources.Load (shipName), transform.position, Quaternion.identity) as GameObject;
		newShip.GetComponent<Health> ().m_respawner = transform;
		//Debug.Log ("Respawned");
	}
		
}