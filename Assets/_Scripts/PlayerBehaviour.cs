using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickSensitivity;
    public float horizontalForce;
    public float jumpForce;
    //public float maximumVelocityX;
    public bool isGrounded;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this._Move();
    }

    private void _Move()
    {
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickSensitivity)
            {
                // move to the right
                rigidbody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = false;
                animator.SetInteger("AnimState", 1);
                //Debug.Log("move Right");
            }
            else if (joystick.Horizontal < -joystickSensitivity)
            {
                // move to the left
                rigidbody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = true;
                animator.SetInteger("AnimState", 1);
                //Debug.Log("move Left");
            }
            else if (joystick.Vertical > joystickSensitivity)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce * Time.deltaTime);
                Debug.Log("move Jump");
            }
            else
            {
                animator.SetInteger("AnimState", 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
