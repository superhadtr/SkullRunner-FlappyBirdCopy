using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    public static bool isMusicOn, musicButtonPressed, reviveBuyed, buyed2x, buyed5, closeButtonPressed, shopButtonPressed, canFly, gameIsStopped,canDie;

    
    public GameObject pausebutton, pausePanel, gameoverScreen;
    public AudioSource clickSound, reviveSound;
    Animator animator;

    void Start()
    {
        canDie = true;
        isMusicOn = true;
        animator = pausebutton.GetComponent<Animator>();
        gameIsStopped = false;
        pausePanel.SetActive(false);
        canFly = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsStopped) { Time.timeScale = 0f; }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        gameIsStopped = false;
        clickSound.Play();
        ButtonScripts.canFly = true;
        PlayerPrefs.SetInt("stopped", 0);
    }
    public void musicOn()
    {
        if (PlayerPrefs.GetInt("musicOn") == 0)
        {
            PlayerPrefs.SetInt("musicOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("musicOn", 0);
        }
        clickSound.Play();


    }
    public void buyRevive()
    {
        if (PlayerPrefs.GetInt("Coin") >= 120)
        {
            if (PlayerPrefs.GetInt("ReviveGoted") == 0)
            {
                
                reviveBuyed = true;
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 120);
                PlayerPrefs.SetInt("ReviveGoted", 1);
            }
        }
        clickSound.Play();

    }
    public void buy2x()
    {
        if (PlayerPrefs.GetInt("Coin") >= 210)
        {
            if (PlayerPrefs.GetInt("2xGoted") == 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 210);
                buyed2x = true;
                PlayerPrefs.SetInt("2xGoted", 1);
            }
        }

        clickSound.Play();
    }

    public void buy5()
    {
        if (PlayerPrefs.GetInt("Coin") >= 80)
        {
            if (PlayerPrefs.GetInt("5+Goted") == 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 80);
                buyed5 = true;
                PlayerPrefs.SetInt("5+Goted", 1);
            }
        }
        clickSound.Play();

    }
    public void closeButton()
    {
        closeButtonPressed = true;
        clickSound.Play();
    }
    public void shopButton()
    {
        shopButtonPressed = true;
        clickSound.Play();
    }
    public void homeButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        clickSound.Play();
    }
    public void pauseButton()
    {
        if (gameIsStopped == false)
        {
            Time.timeScale = 0f;
            animator.SetTrigger("toPlay");
            pausePanel.SetActive(true);
            gameIsStopped = true;
            clickSound.Play();
        }
        else if (gameIsStopped == true)
        {
            Time.timeScale = 1f;
            animator.SetTrigger("toPause");
            pausePanel.SetActive(false);
            gameIsStopped = false;
            clickSound.Play();

        }

    }
    public void exitButton()
    {
        Application.Quit();
        clickSound.Play();
    }
    public void Revive()
    {
        gameoverScreen.SetActive(false);
        canFly = true;
        canDie = false;
        Time.timeScale = 1f;
        StartCoroutine(waitForCloseShield());
        PlayerPrefs.SetInt("ReviveGoted", 0);
        reviveSound.Play();
    }

    IEnumerator waitForCloseShield()
    {
        yield return new WaitForSeconds(3);
        canDie = true;


    }
    public void cantFly()
    {
        canFly = false;
    }
    public void CanFly()
    {
        canFly = true;
    }

}
