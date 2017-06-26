using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public Text dayText;
    private string[] m_dayString = new string[5] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
    public Text moneyText;

    public AudioMixerSnapshot soundOn;
    public AudioMixerSnapshot soundOff;

    public AudioMixerSnapshot sfxOn;
    public AudioMixerSnapshot sfxOff;

    private Camera m_mainCamera;
    public Color[] cameraColours;
    void Start()
    {
        m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (PlayerPrefs.HasKey("Day"))
            dayText.text = m_dayString[PlayerPrefs.GetInt("Day")];
        else
            dayText.text = m_dayString[0];

        if (PlayerPrefs.HasKey("Money"))
            moneyText.text = string.Format("₽{0}", PlayerPrefs.GetFloat("Money"));
        else
            moneyText.text = string.Format("₽0");

        m_achievementPanelImage = achievementPanel.GetComponent<Image>();

        LoadSound();
        LoadFont();
        LoadColourBlindSettings();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public GameObject achievementPanel;
    public void ShowAchievements()
    {
        achievementPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    bool m_musicOn = true;
    public Text musicText;
    
    bool m_sfxOn = true;
    public Text sfxText;

    public void LoadSound()
    {
        if (PlayerPrefs.HasKey("MusicOn"))
        {
            int checkMusic = PlayerPrefs.GetInt("MusicOn");
            int checkSFX = PlayerPrefs.GetInt("SFXOn");

            if(checkMusic == 0)
            {
                musicText.fontStyle = FontStyle.Italic;
                soundOff.TransitionTo(0.1f);
                m_musicOn = false;
            }

            if(checkSFX == 0)
            {
                sfxText.fontStyle = FontStyle.Italic;
                sfxOff.TransitionTo(0.1f);
                m_sfxOn = false;
            }
        }
    }
    public void MusicOn()
    {
        m_musicOn = !m_musicOn;
        if(m_musicOn)
        {
            musicText.fontStyle = FontStyle.Normal;
            soundOn.TransitionTo(0.1f);
            PlayerPrefs.SetInt("MusicOn", 1);
        }
        else
        {
            musicText.fontStyle = FontStyle.Italic;
            soundOff.TransitionTo(0.1f);
            PlayerPrefs.SetInt("MusicOn", 0);
        }
    }

    public void SFXOn()
    {
        m_sfxOn = !m_sfxOn;
        if (m_sfxOn)
        {
            sfxText.fontStyle = FontStyle.Normal;
            sfxOn.TransitionTo(0.1f);
            PlayerPrefs.SetInt("SFXOn", 1);
        }
        else
        {
            sfxText.fontStyle = FontStyle.Italic;
            sfxOff.TransitionTo(0.1f);
            PlayerPrefs.SetInt("SFXOn", 0);
        }
    }

    public void ClickedOnName()
    {
        Application.OpenURL("www.philipnewsham.com");
    }

    public Font[] fonts;
    private int m_currentFontInt;
    private string[] m_fontString = new string[3]
    {
        "Russian",
        "Readable",
        "Dyslexia Friendly"
    };
    public Text fontButtonText;
    public Text[] m_allText;
    public void ChangeFont()
    {
        m_currentFontInt = (m_currentFontInt + 1) % 3;
        fontButtonText.text = string.Format("Font: {0}", m_fontString[m_currentFontInt]);

        for (int i = 0; i < m_allText.Length; i++)
        {
            m_allText[i].font = fonts[m_currentFontInt];
        }

        PlayerPrefs.SetInt("Font", m_currentFontInt);
    }

    void LoadFont()
    {
        if (PlayerPrefs.HasKey("Font"))
            m_currentFontInt = PlayerPrefs.GetInt("Font");
        else
            m_currentFontInt = 0;

        //m_allText = FindObjectsOfType<Text>();
        fontButtonText.text = string.Format("Font: {0}", m_fontString[m_currentFontInt]);

        for (int i = 0; i < m_allText.Length; i++)
        {
            m_allText[i].font = fonts[m_currentFontInt];
        }
    }
    bool m_isColourBlind;
    public Text colourBlindText;

    void LoadColourBlindSettings()
    {
        if(PlayerPrefs.HasKey("ColourBlind"))
        {
            print("Has key for colourblind");
            int m_colBliInt = PlayerPrefs.GetInt("ColourBlind");

            if (m_colBliInt == 0)
                m_isColourBlind = false;
            else
                m_isColourBlind = true;

            m_mainCamera.backgroundColor = cameraColours[m_colBliInt];
            m_achievementPanelImage.color = cameraColours[m_colBliInt];
            m_howToPlayImage.color = cameraColours[m_colBliInt];
            m_currentColourScheme = PlayerPrefs.GetInt("ColourScheme");
            if (m_currentColourScheme == 13)
                m_currentColourScheme = 0;

            if (m_isColourBlind)
                colourBlindText.text = string.Format("colour blind: on");
            else
                colourBlindText.text = string.Format("colour blind: off");
        }
    }

    public void LoadColourScheme()
    {
        m_currentColourScheme = PlayerPrefs.GetInt("ColourScheme");
        if (m_currentColourScheme == 12)
            m_currentColourScheme = 0;
        else if (m_currentColourScheme != 12 && m_isColourBlind)
        {
            //PlayerPrefs.SetInt("ColourScheme", 12);
        }
    }

    private int m_currentColourScheme;
    private Image m_achievementPanelImage;
    public Image m_howToPlayImage;
    public void ColourBlindMode()
    {
        m_isColourBlind = !m_isColourBlind;
        print(m_isColourBlind);

        if (m_isColourBlind)
        {
            colourBlindText.text = string.Format("colour blind: on");
            PlayerPrefs.SetInt("ColourBlind", 1);
            m_mainCamera.backgroundColor = cameraColours[1];
            m_achievementPanelImage.color = cameraColours[1];
            m_howToPlayImage.color = cameraColours[1];
        }
        else
        {
            colourBlindText.text = string.Format("colour blind: off");
            PlayerPrefs.SetInt("ColourBlind", 0);
            m_mainCamera.backgroundColor = cameraColours[0];
            m_achievementPanelImage.color = cameraColours[0];
            m_howToPlayImage.color = cameraColours[0];
        }
        /*
        if (m_isColourBlind)
            colourBlindText.text = string.Format("colour blind: on");
        else
            colourBlindText.text = string.Format("colour blind: off");
            */
    }
}