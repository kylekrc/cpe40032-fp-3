using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enragedBehaviour : StateMachineBehaviour
{
    //variables
    public float timer;
    public float minTime;
    public float maxTime;

    //referencing the player
    public Transform player;
    private int rand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 3);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = Random.Range(minTime, maxTime);
        if (rand <= 0)
        {
            animator.SetTrigger("attack");
        }
        else if (rand <= 1)         //let's boss attack while walking
        {
            animator.SetTrigger("walk");
        }
        else
        {
            animator.SetTrigger("summon");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);      //just like idle state, but there's a new trigger
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
