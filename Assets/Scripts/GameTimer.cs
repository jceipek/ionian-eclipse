using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{

		public float m_topOffset;
		public float m_visualScale = 0.8f;
		public int m_segmentCount = 5;
		public float m_totalTimeToWin;
		public float m_timeTillWin;
		public float[] m_encounterTimes;
		public Texture[] m_timerBarTextures = new Texture[3];
		public Texture m_LocationIconTexture;
		public Texture m_EncounterIconTexture;
		public Texture m_ObjectiveIconTexture;

		private float[] m_points = new float[2];
		private float m_barHeight;
	
		void Update ()
		{
				m_timeTillWin += Time.deltaTime;
				if (m_timeTillWin > m_totalTimeToWin) {
						m_timeTillWin = m_totalTimeToWin;
						// TODO: You win!
				}
		}

		void OnGUI ()
		{
				DrawBar ();
				foreach (float f in m_encounterTimes) {
						DrawIconAtTime (m_EncounterIconTexture, f);
				}
				DrawIconAtTime (m_ObjectiveIconTexture, m_totalTimeToWin);
				DrawIconAtTime (m_LocationIconTexture, m_timeTillWin);
		}

		void DrawIconAtTime (Texture icon, float time)
		{
				GUI.DrawTexture (new Rect (Mathf.Lerp (m_points [0], m_points [1], time / m_totalTimeToWin), 
		                           m_topOffset + (m_timerBarTextures [1].height - icon.height) * m_visualScale / 2f,
		                           icon.width * m_visualScale, icon.height * m_visualScale), icon);
		}

		void DrawBar ()
		{
				float startPos = m_timerBarTextures [0].width * m_visualScale;
				float length = (startPos + (m_segmentCount * m_timerBarTextures [1].width * m_visualScale) + m_timerBarTextures [2].width * m_visualScale);
				float leftOffset = (Screen.width - length) / 2f;
				GUI.DrawTexture (new Rect (leftOffset,
		                                   m_topOffset,
		                                   m_timerBarTextures [0].width * m_visualScale,
		                                   m_timerBarTextures [0].height * m_visualScale),
		                                   m_timerBarTextures [0]);
				for (int i = 0; i < m_segmentCount; i++) {
						GUI.DrawTexture (new Rect (m_timerBarTextures [0].width * m_visualScale + leftOffset + i * m_timerBarTextures [1].width * m_visualScale,
												   m_topOffset, m_timerBarTextures [1].width * m_visualScale,
			                                       m_timerBarTextures [1].height * m_visualScale), m_timerBarTextures [1]);
				}
				GUI.DrawTexture (new Rect (leftOffset + m_timerBarTextures [0].width * m_visualScale + m_segmentCount * m_timerBarTextures [1].width * m_visualScale,
		                                   m_topOffset,
		                                   m_timerBarTextures [2].width * m_visualScale,
		                                   m_timerBarTextures [2].height * m_visualScale),
		                                   m_timerBarTextures [2]);
				m_points [0] = leftOffset + m_timerBarTextures [2].width * m_visualScale;
				m_points [1] = leftOffset + length - m_timerBarTextures [2].width * m_visualScale;
		}
}