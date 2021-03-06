﻿using UnityEngine;
using System.Collections;

public class RadialIndicator : MonoBehaviour
{

	public SpriteRenderer[] m_visualCooldownIndicator;

	void Start ()
	{
		for (int indicatorIndex = 0; indicatorIndex < m_visualCooldownIndicator.Length; indicatorIndex++) {
			UpdateCooldownIndicator (indicatorIndex, 0.001f);
		}
	}

	public void UpdateCooldownIndicator (int indicatorIndex, float fraction)
	{
		m_visualCooldownIndicator [indicatorIndex].sharedMaterial.SetFloat ("_Cutoff", Mathf.Max (fraction, 0.001f));
	}

}
