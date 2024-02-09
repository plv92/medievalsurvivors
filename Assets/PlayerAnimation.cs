using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if  (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SpriteDirection();
        }
        else
        {
            am.SetBool("Move", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PerformAttack());
        }
        if (Input.GetMouseButtonDown(1))
        {
            am.SetBool("Death", true);
        }
    }

    IEnumerator PerformAttack()
    {
        am.SetBool("Attack", true);
        yield return new WaitForSeconds(0.2f);
        am.SetBool("Attack", false);
    }

    void SpriteDirection()
    {
        if (pm.moveDir.x > 0)
        {
            sr.flipX = false;
        }
        else if (pm.moveDir.x < 0)
        {
            sr.flipX = true;
        }
    }
}