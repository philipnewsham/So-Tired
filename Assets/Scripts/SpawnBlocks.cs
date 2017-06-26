using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public Color[] blockColours = new Color[48];
    public GameObject block;
    public Vector2 widthLimit;
    public Vector2 heightLimit;
    public Vector2[] spawnPositions;
    float waitTime;
    private int m_currentSpawn;
    public int currentSpawn = 32;
    private int m_colourScheme;
    private Camera m_mainCamera;
    private Color[] m_cameraColours = new Color[2] { Color.red, Color.white };
    private GameObject m_camera;
	// Use this for initialization
	void Start ()
    {
        m_camera = GameObject.FindGameObjectWithTag("MainCamera");
        blockColours = m_camera.GetComponent<MainMenuAchievements>().blockColours;
        m_mainCamera = m_camera.GetComponent<Camera>();
        if (PlayerPrefs.HasKey("ColourScheme"))
            m_colourScheme = PlayerPrefs.GetInt("ColourScheme");

        if (PlayerPrefs.HasKey("ColourBlind"))
        {
            if(PlayerPrefs.GetInt("ColourBlind") == 1)
            {
                m_colourScheme = 12;
                m_mainCamera.backgroundColor = m_cameraColours[1];
            }
        }


        waitTime = 60 / 32;
        currentSpawn = 32;
        InvokeRepeating("SpawnBlock", waitTime, waitTime);
    }

    public void StartDay()
    {
        currentSpawn = 0;
    }

    void SpawnBlock()
    {
        if (currentSpawn < 32)
        {
            GameObject blockClone = Instantiate(block, spawnPositions[currentSpawn]/*new Vector2(Random.Range(widthLimit.x, widthLimit.y), Random.Range(heightLimit.x, heightLimit.y))*/, Quaternion.identity) as GameObject;
            MoveBlock cloneScript = blockClone.GetComponent<MoveBlock>();
            int chooseColour = Random.Range(m_colourScheme * 4, (m_colourScheme * 4) + 4);
            print(string.Format("colourScheme {0}", m_colourScheme));
            blockClone.GetComponent<SpriteRenderer>().color = blockColours[chooseColour];
            cloneScript.blockColour = chooseColour;
            currentSpawn += 1;
        }
    }

    public void StopDay()
    {
        
    }
    
}
