using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveToDest))]
public class SwarmAIController : MonoBehaviour
{

	public float m_distanceOffset = 4f;
	private MoveToDest m_moveToDest;
	
	// Use this for initialization
	void OnEnable ()
	{
		m_moveToDest = GetComponent<MoveToDest> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 target = GetClosestPlayerPos ();
		Vector3 offset = target - transform.position;
		offset.Normalize ();
		target -= offset * m_distanceOffset;

		m_moveToDest.SetDest (target);
	}

	// TODO: Fix this:
	Vector2 GetClosestPlayerPos ()
	{
		GameObject player = GameObject.Find ("Player");
		if (player)
			return player.transform.position;
		return transform.position;
	}
}