using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SteamVR_TrackedController))]
public class CompassManager : MonoBehaviour
{
    protected bool m_instantiate = false;

    [SerializeField]
    protected GameObject                m_prefabCompass;
    [SerializeField]
    protected GameObject                m_prefabNet;
    [SerializeField]
    protected GameObject                m_prefabScore;

    protected GameObject                m_compass = null;
    protected GameObject                m_score = null;
    protected GameObject                m_net = null;
    [SerializeField]
    protected Transform                 m_objectif;

    protected CompassArrow              m_compassArrow;
    protected SteamVR_TrackedController m_controller;

    protected Game                      m_game;

	// Use this for initialization
	void Start ()
    {
        m_compassArrow = GetComponentInChildren<CompassArrow>();
        m_controller = GetComponent<SteamVR_TrackedController>();
        m_game = FindObjectOfType<Game>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_objectif == null)
            m_objectif = transform;

        if (!m_instantiate)
        {
            Transform score     = transform.Find("Model/body/attach");
            Transform trackpad  = transform.Find("Model/trackpad");
            Transform model     = transform.Find("Model");

            if (trackpad != null)
            {
                m_compass = Instantiate(m_prefabCompass, trackpad);
                m_score = Instantiate(m_prefabScore, score);
                m_net = Instantiate(m_prefabNet, model);

                m_instantiate = true;
            }
        }

        if(m_compassArrow == null)
            m_compassArrow = GetComponentInChildren<CompassArrow>();

        if (m_score != null && m_game != null)
        {
            m_score.transform.Find("Text").GetComponent<Text>().text = m_game.getScore().ToString();
            m_score.transform.Find("Text (2)").GetComponent<Text>().text = m_game.getScoreMax().ToString();
        }

        if(m_compass != null)
        {
            Vector3 north = transform.TransformDirection(Vector3.forward);
            Vector3 direction = m_objectif.position - transform.position;

            Vector2 north2D = new Vector2(north.x, north.z);
            Vector2 direction2D = new Vector2(direction.x, direction.z);

            float angle = Vector2.SignedAngle(north2D, direction2D);

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("needle"))
                item.transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.up);

        }

        if (m_controller.padPressed && m_compassArrow != null)
            m_compassArrow.drawArrow();
    }

    public void setObjectif(Transform p_objectif)
    {
        m_objectif = p_objectif;
    }
}
