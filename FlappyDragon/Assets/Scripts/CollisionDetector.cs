using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public GameObject GameOverScreen, ReviveButton;
    public Text score, highscore, currentscore;
    public static int scoreF, scoreCounter;
    public static bool touched;
    public AudioSource scoreSound, deadSound;


    void Start()
    {

        score.text = string.Empty;
        scoreF = 0;
        GameOverScreen.SetActive(false);
        touched = false;
        ReviveButton.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {



        if (Scene0PanelScript.canUse2x)
        {
            scoreCounter = 2;

        }
        else if (!Scene0PanelScript.canUse2x)
        {
            scoreCounter = 1;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            touched = true;
            Scene0PanelScript.canUse2x = false;
            Scene0PanelScript.canUse5 = false;

            if ((!ShieldScript.isShieldActive) && (!SpeedScript.isSpeedActive) && (ButtonScripts.canDie))
            {
                PlayerPrefs.SetInt("stopped", 1);
                deadSound.Play();
                PlayerPrefs.SetInt("deadCounter", PlayerPrefs.GetInt("deadCounter") + 1);
                ButtonScripts.canFly = false;
                GameOverScreen.SetActive(true);
                Time.timeScale = 0;

                if (Scene0PanelScript.reviveGoted)
                {
                    ReviveButton.SetActive(true);
                }
                if (PlayerPrefs.GetInt("ReviveGoted") == 0)
                {
                    ReviveButton.SetActive(false);
                }
                currentscore.text = scoreF.ToString();
                highscore.text = PlayerPrefs.GetInt("highScore").ToString();

            }




        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointArea"))
        {
            scoreSound.Play();
            scoreF = scoreF + scoreCounter;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + scoreCounter);
            score.text = scoreF.ToString();
            

        }
    }
}
