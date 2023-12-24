using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly : MonoBehaviour
{
    Rigidbody2D dragonRB;
    public float jumpForce, rotationSpeed;
    Animator animator;
    bool canNoDieAnim;
    public AudioSource wingSound;



    void Start()
    {
        canNoDieAnim = true;
        dragonRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!ButtonScripts.canDie && canNoDieAnim) 
        {
            animator.SetTrigger("cantDie");
            canNoDieAnim=false;
            StartCoroutine(waitFor5Sec());
        }
        
        if (Input.GetMouseButtonDown(0) && ButtonScripts.canFly)
        {
            animator.SetBool("Falling", false);
            dragonRB.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jumped");
            wingSound.Play();

        }
        if (dragonRB.velocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, dragonRB.velocity.y * rotationSpeed);
    }

    IEnumerator waitFor5Sec()
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("canDie");
        canNoDieAnim = true;
    }
}
