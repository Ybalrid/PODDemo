using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMRControllerBoostrap : MonoBehaviour
{
    private bool leftOk = false;
    private bool rightOk = false;
    public GameObject m_prefabCompass;
    public GameObject m_prefabNet;
    public GameObject m_prefabScore;

    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    private void configureCompass(CompassManager cm)
    {
        cm.m_prefabCompass = m_prefabCompass;
        cm.m_prefabNet = m_prefabNet;
        cm.m_prefabScore = m_prefabScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (!leftOk)
        {
            Transform T = myTransform.Find("LeftController");
            if (T)
            {
                configureCompass(T.gameObject.AddComponent<CompassManager>());
                leftOk = true;
            }
        }

        if (!rightOk)
        {
            Transform T = myTransform.Find("RightController");
            if (T)
            {
                T.gameObject.AddComponent<CompassManager>();
                rightOk = true;
            }

        }
    }
}