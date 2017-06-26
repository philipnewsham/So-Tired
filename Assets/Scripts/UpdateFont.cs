using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateFont : MonoBehaviour
{
    int m_currentFontInt;
    public Font[] fonts;
    public Text[] m_allText;

    void Start()
    {
        LoadFont();
    }

    void LoadFont()
    {
        if (PlayerPrefs.HasKey("Font"))
            m_currentFontInt = PlayerPrefs.GetInt("Font");
        else
            m_currentFontInt = 0;

        //m_allText = FindObjectsOfType<Text>();

        for (int i = 0; i < m_allText.Length; i++)
        {
            m_allText[i].font = fonts[m_currentFontInt];
        }
    }

}
