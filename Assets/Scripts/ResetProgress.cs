using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetProgress : MonoBehaviour
{

	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            //ResetStats();
            //SceneManager.LoadScene(1);
        }
	}

    public void ResetStats()
    {
        PlayerPrefs.SetInt("Day", 0);
        PlayerPrefs.SetFloat("Money", 35);

        PlayerPrefs.SetInt("DayComplete", 0);
        PlayerPrefs.SetInt("WeekComplete", 0);
        PlayerPrefs.SetInt("ActivityOne", 0);
        PlayerPrefs.SetInt("ActivityTwo", 0);
        PlayerPrefs.SetInt("ActivityThree", 0);
        PlayerPrefs.SetInt("ActivityFour", 0);
        PlayerPrefs.SetInt("ActivityFive", 0);
        PlayerPrefs.SetInt("ActivitySix", 0);
        PlayerPrefs.SetInt("ActivitySeven", 0);
        PlayerPrefs.SetInt("ActivityEight", 0);
        PlayerPrefs.SetInt("NothingDone", 0);
        PlayerPrefs.SetInt("SameColour", 0);

        PlayerPrefs.SetInt("ColourScheme", 0);
        ReturnToMenu();
    }

    public void GameOverRestart()
    {
        PlayerPrefs.SetInt("Day", 0);
        PlayerPrefs.SetFloat("Money", 35);
        ReturnToMenu();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
