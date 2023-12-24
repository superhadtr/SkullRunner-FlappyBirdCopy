using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedScript : MonoBehaviour
{
    Animator animator;
    public static bool isSpeedActive;
    Rigidbody2D rb;
    public static float pipeSpeedmax, pipeSpeedmin, waitSecond;
    public AudioSource electiric;
    

    void Start()
    {
        waitSecond = 7;
        isSpeedActive = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isSpeedActive)
        {
            PipesMovement.speed = 3.5f;
            ScrollingBackground.Speed = 3.5f;
            pipeSpeedmax = 1.39f;
            pipeSpeedmin = 1.04f;
        }
        else
        {
            pipeSpeedmax = 3.2f;
            pipeSpeedmin = 2.4f;
            PipesMovement.speed = 1.5f;
            ScrollingBackground.Speed = 1.5f;
        }
        if (Scene0PanelScript.canUse5)
        {
            waitSecond += 5;
            Scene0PanelScript.canUse5 = false;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedIcon") && !isSpeedActive)
        {
            electiric.Play();
            StartCoroutine(closeSpeed());
            animator.SetBool("SpeedIconTaked", true);
            isSpeedActive = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }

    IEnumerator closeSpeed()
    {
        yield return new WaitForSeconds(waitSecond);
        animator.SetTrigger("SpeedFinish");
        animator.SetBool("SpeedIconTaked", false);
        ShieldScript.isShieldActive = true;
        ButtonScripts.canDie = false;
        isSpeedActive = false;
        rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        StartCoroutine(waitForShield());

    }
    IEnumerator waitForShield()
    {
        yield return new WaitForSeconds(2);
        ShieldScript.isShieldActive = false;
        ButtonScripts.canDie = true;
        
    }

}
