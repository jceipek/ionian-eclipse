using UnityEngine;
using System.Collections;

public class MineAbility : MonoBehaviour
{
	public Transform[] m_minePos;
	private GameObject m_mine;
	public int m_maxMines = 10;
	private int m_numMines = 0;

	void OnEnable ()
	{
		m_mine = Resources.Load ("Mine") as GameObject;
	}
	
	public void Fire ()
	{
		if (m_numMines >= m_maxMines) {
			return;
		}
		foreach (var mineTransform in m_minePos) {
			GameObject mine = Instantiate (m_mine, mineTransform.position, Quaternion.identity) as GameObject;
			MineBehavior mineBehavior = mine.GetComponent<MineBehavior> ();
			mineBehavior.Init (this);
			m_numMines ++;
		}
	}

	public void DecrementMineCount ()
	{
		if (m_numMines > 0) {
			m_numMines--;
		}
	}
}
