using UnityEngine;
using System.Collections;

public class RadialIndicator : MonoBehaviour
{

		public SpriteRenderer[] m_visualCooldownIndicator;

		void Start ()
		{
				for (int indicatorIndex = 0; indicatorIndex < m_visualCooldownIndicator.Length; indicatorIndex++) {
						UpdateCooldownIndicator (indicatorIndex, 0f);
				}
		}

		public void UpdateCooldownIndicator (int indicatorIndex, float fraction)
		{
				m_visualCooldownIndicator [indicatorIndex].sharedMaterial.SetFloat ("_Cutoff", fraction);
		}

}
