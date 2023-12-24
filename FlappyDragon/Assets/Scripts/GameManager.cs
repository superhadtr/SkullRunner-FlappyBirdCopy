using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float highScore;

    public GameObject MusicOnButton;
    public AudioSource music;
    Animator animator;



    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
        animator = MusicOnButton.GetComponent<Animator>();







    }

    // Update is called once per frame
    void Update()
    {


        if (PlayerPrefs.GetInt("musicOn") == 1)
        {
            music.mute = false;
            animator.SetTrigger("musicOpened");
        }
        if (PlayerPrefs.GetInt("musicOn") == 0)
        {
            music.mute = true;
            animator.SetTrigger("musicClosed");
        }

        highScore = PlayerPrefs.GetInt("highScore");
        if (CollisionDetector.scoreF > highScore)
        {
            PlayerPrefs.SetInt("highScore", CollisionDetector.scoreF);
        }

    }
}
