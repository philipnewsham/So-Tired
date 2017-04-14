using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public int minutesPerDay;
    private float m_secondsInDay;
    private float m_countDown;
    private bool m_isCounting = true;

    public GameObject minuteHand;
    private float minuteHandRot;
    public GameObject hourHand;
    // Use this for initialization
    void Start()
    {
        m_secondsInDay = minutesPerDay * 60f;
        m_countDown = m_secondsInDay;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isCounting)
        {
            m_countDown -= Time.deltaTime;
            hourHand.transform.eulerAngles = new Vector3(0, 0, hourHand.transform.eulerAngles.z - ((240/m_secondsInDay) * Time.deltaTime));
            minuteHand.transform.eulerAngles = new Vector3(0, 0, minuteHand.transform.eulerAngles.z - ((2880 / m_secondsInDay) * Time.deltaTime));
            if (m_countDown <= 0f)
            {
                m_isCounting = false;
                EndOfDay();
            }
        }
    }

    void EndOfDay()
    {

    }
}

