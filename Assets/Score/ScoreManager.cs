using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private int score;

    private AudioSource audio;
    public AudioClip scoreSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = scoreSound;
        audio.loop = false;
        GameObject scoreObj = GameObject.Find("Score");
        this.scoreText = scoreObj.GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        audio.Play();
        score += 1;
        this.scoreText.text = "Score: " + score.ToString();
    }
}
