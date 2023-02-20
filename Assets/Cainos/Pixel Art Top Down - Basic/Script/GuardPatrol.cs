using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int patrolIndex = 0;
    public float speed;

    private Animator animator;
    private float waitTime;
    public float startWaitTime;
    private bool patrolPointReached;

    private void Start()
    {
        patrolPointReached = false;
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        ContinuePatrol();
    }


    private void Update()
    {
        if(Vector2.Distance(this.transform.position, patrolPoints[patrolIndex].transform.position) < 0.35) {
            patrolIndex = (patrolIndex+1)%patrolPoints.Length;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetBool("IsMoving", false);
            patrolPointReached = true;
        }

        if(patrolPointReached) {
            if(waitTime <= 0) {
            waitTime = startWaitTime;
            ContinuePatrol();
            patrolPointReached = false;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void ContinuePatrol() {
        Vector2 dir = Vector2.zero;
        if(patrolIndex == 0) { 
            dir.x = -1;
            animator.SetInteger("Direction", 3); /* Animate Left */
        } else if(patrolIndex == 1) { 
            dir.y = 1;
            animator.SetInteger("Direction", 1); /* Animate Up */
        } else if(patrolIndex == 2) { 
            dir.x = 1;
            animator.SetInteger("Direction", 2); /* Animate Right */
        } else { 
            dir.y = -1;
            animator.SetInteger("Direction", 0); /* Animate Down */
        }
        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}

