using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CatchEggs : MonoBehaviour
{
    protected Game              m_game;
    protected SpawnerEggs       m_spawner;

    protected List<GameObject>  m_fireworks = null;

    // Use this for initialization
    void Start ()
    {
        m_game = FindObjectOfType<Game>();
        m_spawner = FindObjectOfType<SpawnerEggs>();

        m_fireworks = m_spawner.getFireworks();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        int index;

        index = m_game.isGoal(other.gameObject);

        if (index >= 0 && index < m_fireworks.Count)
            m_fireworks[index].SetActive(true);
    }
}
