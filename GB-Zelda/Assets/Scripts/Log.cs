using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform Target;
    public float ChaseRadius; // radius log will chase after player
    public float AttackRadius; //radius log will attack player
    public Transform homePosition; // start/return position

    public Animator animator;

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = EnemyState.idle;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator =  GetComponent<Animator>();
        Target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(Target.position, transform.position) <= ChaseRadius && Vector3.Distance(Target.position, transform.position) > AttackRadius) 
        {
            if(CurrentState == EnemyState.idle || CurrentState == EnemyState.walking && CurrentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);
                
                ChangeAnimation(temp - transform.position);
                rigidbody2D.MovePosition(temp);
                
                ChangeState(EnemyState.walking);
                animator.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(Target.position, transform.position) > ChaseRadius)
        {
            animator.SetBool("wakeUp", false);
        }
    }

    private void SetAnimationFloat(Vector2 setVector)
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }

    private void ChangeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimationFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimationFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x ) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0)
            {
                SetAnimationFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimationFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(CurrentState != newState)
        {
            CurrentState = newState;
        }
    }
}
