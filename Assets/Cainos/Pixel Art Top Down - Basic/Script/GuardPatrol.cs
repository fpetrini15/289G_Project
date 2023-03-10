using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public Transform[] patrolPoints;
    public int patrolIndex;
    public int previousPatrolIndex;
    public float speed;
    public string defaultDirection;

    private Animator animator;
    private float waitTime;
    public float startWaitTime;
    private bool patrolPointReached; 
    string currentDirection;

    private void Start()
    {
        patrolIndex = 0;
        previousPatrolIndex = 0;
        patrolPointReached = false;
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        StartPatrol();

    }


    private void Update()
    {
        if(Vector2.Distance(this.transform.position, patrolPoints[patrolIndex].transform.position) < 0.35) {
            previousPatrolIndex = patrolIndex;
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
        } else {
            transform.position = GetComponent<Rigidbody2D>().position;
            UpdateFOVDirection();
        }
    }

    private void StartPatrol() {
        Vector2 dir = Vector2.zero;
        if(defaultDirection == "Left") { 
            dir.x = -1;
            animator.SetInteger("Direction", 3); /* Animate Left */
        } else if(defaultDirection == "Up") { 
            dir.y = 1;
            animator.SetInteger("Direction", 1); /* Animate Up */
        } else if(defaultDirection == "Right") { 
            dir.x = 1;
            animator.SetInteger("Direction", 2); /* Animate Right */
        } else { 
            dir.y = -1;
            animator.SetInteger("Direction", 0); /* Animate Down */
        }
        currentDirection = defaultDirection;
        UpdateFOVDirection();
        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
        transform.position = GetComponent<Rigidbody2D>().position;
    }

    private void ContinuePatrol() {
        Vector2 dir = Vector2.zero;
        Vector2 nextPatrolPoint = patrolPoints[patrolIndex].transform.position;
        Vector2 currentPatrolPoint = patrolPoints[previousPatrolIndex].transform.position;
        Vector2 normalizedDirection = nextPatrolPoint - currentPatrolPoint;
        
        if(normalizedDirection[0] != 0.0) { /* Move along X-axis */
            if(normalizedDirection[0] > 0) {
                dir.x = 1;
                animator.SetInteger("Direction", 2); /* Animate Right */
                currentDirection = "Right";
            } else {
                dir.x = -1;
                animator.SetInteger("Direction", 3); /* Animate Left */
                currentDirection = "Left";
            }
        }
        else {
            if(normalizedDirection[1] > 0) { /* Move along Y-axis */
                dir.y = 1;
                animator.SetInteger("Direction", 1); /* Animate Up */
                currentDirection = "Up";
            } else {
                dir.y = -1;
                animator.SetInteger("Direction", 0); /* Animate Down */
                currentDirection = "Down";
            }
        }
        UpdateFOVDirection();
        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);
        GetComponent<Rigidbody2D>().velocity = speed * dir;
        transform.position = GetComponent<Rigidbody2D>().position;
    }

    private void UpdateFOVDirection() {
        if(fieldOfView != null) {
            Vector3 aimDirection = (patrolPoints[patrolIndex].transform.position - transform.position).normalized;
            fieldOfView.SetAimDirection(aimDirection);
            fieldOfView.SetOrigin(transform.position);
        }
    }
}

// 60.240.150.330

