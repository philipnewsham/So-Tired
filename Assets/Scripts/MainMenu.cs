using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text dayText;
    private string[] m_dayString = new string[5] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
    public Text moneyText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Day"))
            dayText.text = m_dayString[PlayerPrefs.GetInt("Day")];
        else
            dayText.text = m_dayString[0];

        if (PlayerPrefs.HasKey("Money"))
            moneyText.text = string.Format("₽{0}", PlayerPrefs.GetFloat("Money"));
        else
            moneyText.text = string.Format("₽0");
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
}
