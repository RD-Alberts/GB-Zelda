using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //how fast the player moves
    private Rigidbody2D rigidbody2d;
    private Vector3 change; //change player position
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
         //if the player is moving
        if(change != Vector3.zero)
        {
            MoveCharacter();
            //change the idle animation
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);

            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    //move the character
    void MoveCharacter()
    {
        rigidbody2d.MovePosition(
            transform.position + change.normalized * speed * Time.deltaTime);
    }


}
