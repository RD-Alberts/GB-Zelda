using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //how fast the player moves
    private Rigidbody2D rigidbody2d;
    private Vector3 changePosition; //change player position
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        changePosition = Vector3.zero;
        changePosition.x = Input.GetAxisRaw("Horizontal");
        changePosition.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
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
        rigidbody2d.MovePosition(transform.position + changePosition * speed * Time.deltaTime);
    }


}
