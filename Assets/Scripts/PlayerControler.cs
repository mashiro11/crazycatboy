using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public int maxSpeed;


    private Transform transform;

    [SerializeField]
    public Transform novoPote;

    // Use this for initialization
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    private bool facingRight;
    private bool idle;

    private bool canPutFood;
    private bool canOpenWindow;

    private GameObject poteComida;
    
    private GameObject room;
    void Start () {
        poteComida = null;
        canPutFood = false;
        canOpenWindow = false;
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
            if(canPutFood) poteComida.GetComponent<PoteComida>().EnchePote();
            if (canOpenWindow)
            {
                GameObject.FindGameObjectWithTag("Window").GetComponent<WindowController>().WindowToggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            CompraPote();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void CompraPote()
    {
        GameObject.Instantiate(novoPote, new Vector3(transform.position.x + 2.2f, transform.position.y - 45f, 0f), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("actionSpace"))
        {
            canPutFood = true;
            poteComida = other.gameObject.transform.parent.gameObject;
            
        }
        if (other.gameObject.name.Equals("Window"))
        {
            canOpenWindow = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("actionSpace"))
        {
            canPutFood = false;
            poteComida = null;
        }
        if (other.gameObject.name.Equals("Window"))
        {
            canOpenWindow = false;
        }
    }

}
