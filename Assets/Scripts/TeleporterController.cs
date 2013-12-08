using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RadialIndicator))]
public class TeleporterController : MonoBehaviour
{
		public string[] m_controlAxis = new string[2];
		public string[] m_shadowControlAxis = new string[2];
		public bool m_teleportButtonIsAxis;
		public string[] m_teleportButtons = new string[2];
		public MoveBehavior m_moveBehavior;
		public MoveBehavior m_shadowMoveBehavior;
		public float m_teleportCooldownSeconds;
		public float m_carryRadius = 5f;
		public float m_unisonTime = 0.1f;

		private RadialIndicator m_visualCooldownIndicator;
		private ShadowAttackAbility m_shadowAttackAbility;
		private bool m_canTeleport = true;
		private Collider2D[] m_overlapCircleResults = new Collider2D[20];

		void OnEnable ()
		{
				m_shadowAttackAbility = GetComponent<ShadowAttackAbility> ();
				m_visualCooldownIndicator = GetComponent<RadialIndicator> ();
		}

		void Start ()
		{
				UpdateCooldownIndicator (0f);
		}

		void FixedUpdate ()
		{
				// Just one key
				if (m_canTeleport) {
						if (OneKeyPressed ()) {
								StartCoroutine (UnisonTeleport (m_unisonTime));
						} else if (BothKeysPressed ()) {
								var oldPos = m_moveBehavior.transform.position;
								var newPos = m_shadowMoveBehavior.transform.position;
								BasicTeleportFrom (oldPos, newPos);
								TeleportSurroundingsTo (newPos, oldPos);
						}
				}


				float horizontal = Input.GetAxis (m_controlAxis [0]);
				float vertical = Input.GetAxis (m_controlAxis [1]);
		
				float shadowHorizontal = Input.GetAxis (m_shadowControlAxis [0]);
				float shadowVertical = Input.GetAxis (m_shadowControlAxis [1]);
				m_moveBehavior.Move (horizontal, -vertical);
				m_shadowMoveBehavior.Move (shadowHorizontal, -shadowVertical);
		}

		bool BothKeysPressed ()
		{
				bool teleportButton1 = !m_teleportButtonIsAxis && Input.GetButtonDown (m_teleportButtons [0]);
				bool teleportAxis1 = m_teleportButtonIsAxis && (Input.GetAxis (m_teleportButtons [0]) > 0.1f);
				bool teleportButton2 = !m_teleportButtonIsAxis && Input.GetButtonDown (m_teleportButtons [1]);
				bool teleportAxis2 = m_teleportButtonIsAxis && (Input.GetAxis (m_teleportButtons [1]) > 0.1f);
				return (teleportButton1 || teleportAxis1) && (teleportButton2 || teleportAxis2);
		}

		bool OneKeyPressed ()
		{
				bool teleportButton1 = !m_teleportButtonIsAxis && Input.GetButtonDown (m_teleportButtons [0]);
				bool teleportAxis1 = m_teleportButtonIsAxis && (Input.GetAxis (m_teleportButtons [0]) > 0.1f);
				bool teleportButton2 = !m_teleportButtonIsAxis && Input.GetButtonDown (m_teleportButtons [1]);
				bool teleportAxis2 = m_teleportButtonIsAxis && (Input.GetAxis (m_teleportButtons [1]) > 0.1f);
				return (teleportButton1 || teleportAxis1) != (teleportButton2 || teleportAxis2);
		}

		IEnumerator UnisonTeleport (float seconds)
		{
				Vector3 oldPos, newPos;
				bool done = false;
				float total = seconds;
				float delta = Time.deltaTime;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						if (BothKeysPressed () && m_canTeleport) {
								done = true;
								oldPos = m_moveBehavior.transform.position;
								newPos = m_shadowMoveBehavior.transform.position;
								BasicTeleportFrom (oldPos, newPos);
								TeleportSurroundingsTo (newPos, oldPos);
						}

				}

				if (!done && m_canTeleport) {
						oldPos = m_moveBehavior.transform.position;
						newPos = m_shadowMoveBehavior.transform.position;
						BasicTeleportFrom (oldPos, newPos);
						TeleportAttackBetween (oldPos, newPos);
				}
		}

		IEnumerator CoolDown ()
		{
				float total = m_teleportCooldownSeconds;
				float delta = Time.deltaTime;
				while (total > 0) {
						yield return new WaitForSeconds (delta);
						total -= delta;
						UpdateCooldownIndicator (total / m_teleportCooldownSeconds);
				}
				m_canTeleport = true;
		}

		void UpdateCooldownIndicator (float fraction)
		{
				m_visualCooldownIndicator.UpdateCooldownIndicator (0, fraction);
		}

		void TeleportSurroundingsTo (Vector2 origin, Vector2 destination)
		{
				int hitCount = Physics2D.OverlapCircleNonAlloc (origin, m_carryRadius, m_overlapCircleResults);
				for (var i = 0; i < hitCount; i++) {
						Collider2D unfortunate = m_overlapCircleResults [i];
						if (unfortunate && unfortunate.GetComponent<CanBeCarriedInTeleport> ()) {
								unfortunate.transform.position = ((Vector3)destination) + (((Vector3)origin) - unfortunate.transform.position);
						}
				}
		}

		void TeleportAttackBetween (Vector3 oldPos, Vector3 newPos)
		{
				if (m_shadowAttackAbility) {
						m_shadowAttackAbility.Attack ();
				}
		}

		void BasicTeleportFrom (Vector3 oldPos, Vector3 newPos)
		{
				m_canTeleport = false;
		
				m_moveBehavior.transform.position = newPos;
				m_shadowMoveBehavior.transform.position = oldPos;
				StartCoroutine (CoolDown ());
		}
	
}