using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public int maxSpeed;


    private Transform transform;
    // Use this for initialization
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    private bool facingRight;
    private bool idle;
    
    private GameObject room;
    void Start () {
        facingRight = true;
        idle = true;
        transform = (Transform) gameObject.GetComponent<Transform>();
        rigidBody2D = (Rigidbody2D) gameObject.GetComponent<Rigidbody2D>();
        animator = (Animator) gameObject.GetComponent<Animator>();
        rigidBody2D.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        if (moveX != 0)
        {
            if (moveX > 0)
            {
                animator.SetBool("walkingUp", false);
                animator.SetBool("walkingDown", false);
                animator.SetBool("walkingHorizontal", true);
                if (!facingRight)
                {
                    Flip();
                }
            }
            else if (moveX < 0)
            {
                animator.SetBool("walkingUp", false);
                animator.SetBool("walkingDown", false);
                animator.SetBool("walkingHorizontal", true);
                if (facingRight)
                {
                    Flip();
                }
            }
        }
        else
        {
            animator.SetBool("walkingHorizontal", false);
        }

        if (moveY != 0)
        {
            if (moveY > 0)
            {
                animator.SetBool("walkingHorizontal", false);
                animator.SetBool("walkingUp", true);
            }
            else if (moveY < 0)
            {
                animator.SetBool("walkingHorizontal", false);
                animator.SetBool("walkingUp", false);
                animator.SetBool("walkingDown", true);
            }
        }
        else
        {
            animator.SetBool("walkingUp", false);
            animator.SetBool("walkingDown", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Realizar ação");
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Room"))
        {
            Debug.Log("Colidiu");
        }

    }

}
