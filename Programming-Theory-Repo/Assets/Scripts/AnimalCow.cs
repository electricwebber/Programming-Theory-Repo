using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCow : Animal
{
    private Animator animator;

    void Start(){
        animator=GetComponent<Animator>();
        jumpSpeed=5;
        walkSpeed=2;
        turnSpeed=20;
    }

    public override void Jump(){
        animator.SetFloat("Speed_f",3);
        base.Jump();
    }

    public override void onJumpEnded(){
        animator.SetFloat("Speed_f",0);
        base.onJumpEnded();
    } 

    public override string GetName(){
        return "Cow";
    }
}
