using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState CurrentState;
    public float speed; //how fast the player moves
    private Rigidbody2D rigidbody2D;
    private Vector3 changePosition; //change player position
    private Animator animator;
    public FloatValue CurrentHealth;
    public Signal PlayerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = PlayerState.walk;
        rigidbody2D= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        changePosition = Vector3.zero;
        changePosition.x = Input.GetAxisRaw("Horizontal");
        changePosition.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("attack") && CurrentState != PlayerState.attack && CurrentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if(CurrentState == PlayerState.walk || CurrentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    //delay attack
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        CurrentState = PlayerState.attack;
        yield return null; //wait a frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f); //wait a 1/3 a sec
        CurrentState = PlayerState.walk;
    }

    private void UpdateAnimationAndMove()
    {
        if (changePosition != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", changePosition.x);
            animator.SetFloat("moveY", changePosition.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    //move the character
    private void MoveCharacter()
    {
        //makes it so diagnal is not much faster then x or y
        changePosition.Normalize();
        rigidbody2D.MovePosition(transform.position + changePosition * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        CurrentHealth.InitialValue -= damage;

        //stagger if there is health
        if(CurrentHealth.InitialValue > 0)
        {    
            PlayerHealthSignal.Raise();
            StartCoroutine(KnockCo(knockTime));
        }
    }

    private IEnumerator KnockCo( float knockTime)
    {
        if (rigidbody2D != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody2D.velocity = Vector2.zero;
            CurrentState = PlayerState.idle;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
