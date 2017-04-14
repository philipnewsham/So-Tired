using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlocks : MonoBehaviour
{
    int currentBlockCount;
    public GameObject[] startingPositions;
    public void AddBlockCount()
    {
        currentBlockCount += 1;
        if(currentBlockCount == 1)
        {
            for (int i = 0; i < startingPositions.Length; i++)
            {
                startingPositions[i].SetActive(false);
            }
        }
    }
}
