using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfWeekButtons : MonoBehaviour {
    public Button[] endOfWeekButtons;

    public void TurnOffButtons()
    {
        for (int i = 0; i < endOfWeekButtons.Length; i++)
        {
            endOfWeekButtons[i].interactable = false;
        }
    }

}
