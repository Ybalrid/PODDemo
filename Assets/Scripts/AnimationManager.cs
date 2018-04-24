using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public float m_speedScale;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Animation>()["Take 001"].speed = m_speedScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
