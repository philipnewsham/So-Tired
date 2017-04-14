using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public Color[] blockColours;
    public int currentDay;
    public GameObject block;
    public Vector2 widthLimit;
    public Vector2 heightLimit;
    public Vector2[] spawnPositions;
    float waitTime;
    private int m_currentSpawn;
	// Use this for initialization
	void Start ()
    {
        waitTime = 60 / 32;
        InvokeRepeating("SpawnBlock", waitTime, waitTime);
	}

    void SpawnBlock()
    {
        if (m_currentSpawn < 32)
        {
            GameObject blockClone = Instantiate(block, spawnPositions[m_currentSpawn]/*new Vector2(Random.Range(widthLimit.x, widthLimit.y), Random.Range(heightLimit.x, heightLimit.y))*/, Quaternion.identity) as GameObject;
            MoveBlock cloneScript = blockClone.GetComponent<MoveBlock>();
            int chooseColour = Random.Range(0, blockColours.Length);
            blockClone.GetComponent<SpriteRenderer>().color = blockColours[chooseColour];
            cloneScript.blockColour = chooseColour;
            m_currentSpawn += 1;
        }
    }
}
