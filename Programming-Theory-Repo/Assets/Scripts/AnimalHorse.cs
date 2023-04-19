using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHorse : Animal
{

    private Animator animator;

    void Start(){
        animator=GetComponent<Animator>();
        jumpSpeed=10;
        walkSpeed=10;
        turnSpeed=50;
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
        return "Horse";
    }
}
