using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    protected float m_duration;
    protected float m_beginTime = -1.0f;

    // Use this for initialization
    void OnEnable ()
    {
        Debug.Log("Youhou");
        m_beginTime = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //*
        if (m_beginTime > 0.0f && Time.realtimeSinceStartup > m_beginTime + m_duration)
            Destroy(gameObject);//*/
	}
}
