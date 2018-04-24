using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignManager : MonoBehaviour
{
    [SerializeField]
    protected List<string>      m_signText;
    protected int               m_currentText;

    [SerializeField]
    protected KeyCode           m_keycode;

    [SerializeField]
    protected Text              m_text;

	// Use this for initialization
	void Start ()
    {
        m_currentText = 0;
        m_text.text = m_signText[m_currentText];
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(m_keycode))
        {
            m_currentText++;
            m_currentText %= m_signText.Count;

            m_text.text = m_signText[m_currentText];
        }
	}
}
