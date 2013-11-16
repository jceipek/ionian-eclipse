using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveToDest))]
public class SwarmAIController : MonoBehaviour
{

	public float m_distanceOffset = 4f;
	private MoveToDest m_moveToDest;
	private Vector3 m_closestPlayerPos;
	
	private Collider2D[] m_overlapCircleResults = new Collider2D[10];

	// Use this for initialization
	void OnEnable ()
	{
		m_moveToDest = GetComponent<MoveToDest> ();
	}

	void Start ()
	{
		StartCoroutine (LowFrequencyUpdater ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 target = m_closestPlayerPos;
		Vector3 offset = target - transform.position;
		offset.Normalize ();
		target -= offset * m_distanceOffset;

		m_moveToDest.SetDest (target);
	}
	
	void UpdateClosestPlayerPos ()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		if (players.Length > 0) {
			float closest = Mathf.Infinity;
			foreach (var player in players) {
				float dist = (player.transform.position - transform.position).sqrMagnitude;
				if (dist < closest) {
					m_closestPlayerPos = player.transform.position;
					closest = dist;
				}
			}
		} else {
			m_closestPlayerPos = transform.position;
		}
	}

	void PushAwayFriends ()
	{
		int hitCount = Physics2D.OverlapCircleNonAlloc ((Vector2)transform.position, 3f, m_overlapCircleResults);
		for (var i = 0; i < hitCount; i++) {
			Collider2D friend = m_overlapCircleResults [i];
			if (friend) {
				if (friend.tag == "Enemy") {
					friend.rigidbody2D.AddForce ((transform.position - friend.transform.position) * -40f);
				}
			}
		}
	}

	IEnumerator LowFrequencyUpdater ()
	{
		while (true) {
			yield return new WaitForSeconds (0.1f);
			UpdateClosestPlayerPos ();
			PushAwayFriends ();
		}
	}
}