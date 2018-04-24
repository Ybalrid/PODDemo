using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    protected List<GameObject>      m_goals = null;
    protected GameObject[]          m_compasses = null;
    protected int                   m_score = 0;
    protected int                   m_nbGoals;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_compasses == null || m_compasses.Length <= 0)
            m_compasses = GameObject.FindGameObjectsWithTag("compass");

		if(m_goals != null && m_goals.Count > 0 && m_compasses != null && m_compasses.Length > 0)
        {
            foreach (GameObject item in m_compasses)
            {
                item.GetComponent<CompassManager>().setObjectif(m_goals[0].transform);
            }
        }

        if(m_score > 0 && m_score == m_nbGoals)
        {
            // TODO : Gestion de la fin
        }

	}

    public void SetGoals(List<GameObject> p_goals)
    {
        m_score = 0;
        m_goals = p_goals;
        m_nbGoals = p_goals.Count;
    }

    public int isGoal(GameObject p_goal)
    {
        int result = -1;

        if(p_goal == m_goals[0])
        {
            result = m_score;

            Destroy(m_goals[0]);
            m_goals.RemoveAt(0);
            m_score += 1;

            foreach (GameObject item in m_compasses)
            {
                item.GetComponent<CompassManager>().setObjectif(m_goals[0].transform);
            }
        }

        return result;
    }

    public int getScore()
    {
        return m_score;
    }

    public int getScoreMax()
    {
        return m_nbGoals;
    }
}
