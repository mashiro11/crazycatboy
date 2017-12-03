using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoControler : MonoBehaviour
{
    [SerializeField]
    public float timeToWalk;

    [SerializeField]
    public float timeToEat;

    [SerializeField]
    public float moveSpeed;

    private float timeToWalkTimer;
    private float timeToEatTimer;

    [SerializeField]
    public float timeToSleep =0f;

    private const int window = 3;

    [SerializeField]
    public bool isSleeping = false;

    [SerializeField]
    public bool goWalk = false;

    [SerializeField]
    public float timeToWake = 0f;

    Vector3 destionation;

    Animator animator;
    // Use this for initialization

    void Start()
    {
        moveSpeed = 20f;
        timeToWalk = 5f;
        timeToEat = 30f;
        timeToEatTimer = 0f;
        timeToWalkTimer = 0f;
        animator = (Animator)gameObject.GetComponent<Animator>();
        destionation.x = 0f;
        destionation.y = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isSleeping == false)
        {
            timeToSleep += Time.deltaTime;
            if (timeToSleep > 15)
            {
                animator.SetTrigger("timeToSleep");
                if (Random.Range(0, 2) > 1)
                {
                    isSleeping = true;
                }
                else
                {
                    goWalk = true;
                }
                timeToSleep = 0;
            }
        }
        if (isSleeping == true) {
            timeToWake += Time.deltaTime;
            if (timeToWake > 15) {
                animator.SetTrigger("timeToWake");
                isSleeping = false;
                timeToWake = 0;
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ) {
            timeToWalkTimer += Time.deltaTime;
            if (timeToWalkTimer > timeToWalk)
            {
                animator.SetTrigger("goWalk");
                animator.SetBool("walking", true);
                destionation.x = Random.Range(-10f, 5f);
                destionation.y = Random.Range(-20f, 15f);
                timeToWalkTimer = 0f;
            }

        }
        if (timeToEatTimer > timeToEat)
        {
            animator.SetBool("isHungry", true);
            timeToEatTimer = 0f;
        }

        if (animator.GetBool("walking"))
        {
            bool moveX = false;
            bool moveY = false;

            Transform transform = (Transform)gameObject.GetComponent<Transform>();
            Vector3 temp = transform.position;
            if(destionation.x - window > temp.x)
            {
                temp.x += Time.deltaTime;
                moveX = true;
            }
            else if(destionation.x + window < temp.x)
            {
                temp.x -= Time.deltaTime;
                moveX = true;
            }
            if (destionation.y - window > temp.y)
            {
                temp.y += Time.deltaTime;
                moveY = true;
            }
            else if(destionation.y + window < temp.y)
            {
                temp.y -= Time.deltaTime;
                moveY = true;
            }
            if (moveX || moveY)
            {
                transform.position = temp;
            }
            else
            {
                animator.SetBool("walking", false);
            }
        }
    }
}