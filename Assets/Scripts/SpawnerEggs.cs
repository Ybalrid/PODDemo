using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEggs : MonoBehaviour
{
    [SerializeField]
    protected int               m_nbEasterEgg;
    [SerializeField]
    protected GameObject        m_prefab;
    [SerializeField]
    protected GameObject        m_prefabFirework;
    [SerializeField]
    protected List<Material>    m_materialList;

    protected GameObject[]      m_spawnerList;
    protected List<GameObject>  m_eggs = null;
    protected List<GameObject>  m_fireworks = null;

    // Use this for initialization
    void Start ()
    {
        Init();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Init();
	}

    private void Init()
    {
        m_spawnerList = GameObject.FindGameObjectsWithTag("spawnerPosition");
        m_nbEasterEgg = m_nbEasterEgg > m_spawnerList.Length ? m_spawnerList.Length : m_nbEasterEgg;
        if (m_eggs == null)
        {
            m_eggs = new List<GameObject>();
            m_fireworks = new List<GameObject>();
        }
        else
        {
            for (int i = 0; i < m_eggs.Count; i++)
                Destroy(m_eggs[i]);

            for (int i = 0; i < m_fireworks.Count; i++)
                Destroy(m_fireworks[i]);

            m_eggs.Clear();
            m_fireworks.Clear();
        }

        List<Transform> positions = new List<Transform>();
        foreach (GameObject item in m_spawnerList)
            positions.Add(item.transform);

        Debug.Log("nb egg : " + m_nbEasterEgg);

        for (int i = 0; i < m_nbEasterEgg; i++)
        {
            int alea = Random.Range(0, positions.Count);
            int aleaMaterial = Random.Range(0, m_materialList.Count);

            m_eggs.Add(Instantiate(m_prefab, positions[alea]));
            m_fireworks.Add(Instantiate(m_prefabFirework, positions[alea]));
            m_fireworks[m_fireworks.Count - 1].SetActive(false);

            GameObject egg = m_eggs[m_eggs.Count - 1].transform.Find("Butterfly.Root/rope/egg").gameObject;
            egg.GetComponent<Renderer>().material = m_materialList[aleaMaterial];
            positions.RemoveAt(alea);
        }

        GetComponent<Game>().SetGoals(m_eggs);
    }

    public List<GameObject> getFireworks()
    {
        return m_fireworks;
    }
}
