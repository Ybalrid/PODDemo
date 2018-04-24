using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassArrow : MonoBehaviour
{
    [SerializeField]
    protected float         m_duration;
    protected float         m_beginTime = 0.0f;

    protected GameObject    m_child;

	// Use this for initialization
	void Start ()
    {
        m_beginTime = -m_duration;
        m_child = GetComponentInChildren<Renderer>().gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float time = Time.realtimeSinceStartup;
        time -= m_beginTime;

        float alpha = 256.0f - Mathf.Min(time * 256.0f / m_duration, 256.0f);
        alpha /= 256.0f;

        if (alpha > 0.01f)
        {
            m_child.SetActive(true);
            Color col = m_child.GetComponent<Renderer>().material.GetColor("_Color");
            col.a = alpha;
            m_child.GetComponent<Renderer>().material.SetColor("_Color", col);
        }
        else
        {
            m_child.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            drawArrow();
	}

    public void drawArrow()
    {
        m_beginTime = Time.realtimeSinceStartup;
    }
}
