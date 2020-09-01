using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Animator swordAnimation;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        anim.SetBool("Jump", jumping);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordAnimation.SetTrigger("SwordAnimation");
    }


    public void Death()
    {
        anim.SetTrigger("Death");
    }
}
