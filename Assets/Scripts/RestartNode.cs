using UnityEngine;
using System.Collections;

public class RestartNode : MonoBehaviour
{
		public string mainLevel = "Main";
		private bool m_restartable;
		void Start ()
		{
				m_restartable = false;
				StartCoroutine (AllowRestart ());
		}
		void Restart ()
		{
				Application.LoadLevel (mainLevel);
		}
		IEnumerator AllowRestart ()
		{
				yield return new WaitForSeconds (3f);
				m_restartable = true;
		}
		void Update ()
		{
				if (Input.anyKey && m_restartable) {
						Restart ();
				}
		}
}
