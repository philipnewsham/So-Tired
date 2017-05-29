using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetProgress : MonoBehaviour
{

	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ResetStats();
        }
	}

    public void ResetStats()
    {
        if (PlayerPrefs.HasKey("Day"))
            PlayerPrefs.SetInt("Day", 0);
        if (PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetFloat("Money", 0);

        SceneManager.LoadScene(0);
    }
}
