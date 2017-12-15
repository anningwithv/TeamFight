using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour
{
    public Text m_textName = null;
    public Text m_textCount = null;
    public Button m_btnJoin = null;

	void Start ()
    {
        m_btnJoin.onClick.AddListener(delegate ()
        {

        });
    }

    public void SetContent(string name, string count)
    {
        m_textCount.text = count;
        m_textName.text = name;
    }
}
