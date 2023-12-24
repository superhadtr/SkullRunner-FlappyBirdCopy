using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public GameObject shield;
    public AudioSource shieldSound;
    public static bool isShieldActive;
    public static float waitSeconds;

    void Start()
    {
        waitSeconds = 7;
        shield.SetActive(false);
        isShieldActive = false;
        PlayerPrefs.SetInt("5+Goted", 0);
        PlayerPrefs.SetInt("2xGoted", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionDetector.touched)
        {
            shield.SetActive(false);
            isShieldActive = false;
            CollisionDetector.touched = false;
        }
        if (Scene0PanelScript.canUse5)
        {
            waitSeconds += 5;
            Scene0PanelScript.canUse5 = false;
        }

    }

    IEnumerator closeShield()
    {
        yield return new WaitForSeconds(waitSeconds);
        shield.SetActive(false);
        ButtonScripts.canDie = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.CompareTag("ShieldIcon")) && (!isShieldActive) && (!SpeedScript.isSpeedActive))
        {
            shield.SetActive(true);
            
            shieldSound.Play();
            isShieldActive = true;
            StartCoroutine(closeShield());
            collision.gameObject.SetActive(false);


        }
    }

    
}
