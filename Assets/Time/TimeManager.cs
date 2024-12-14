using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private Text timeText;
    private float timeCount = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject timeObj = GameObject.Find("Time");
        this.timeText = timeObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        this.timeText.text = "<color=#ff0000>" + ((int)timeCount).ToString() + "</color>";

        if (timeCount <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
    }
}
