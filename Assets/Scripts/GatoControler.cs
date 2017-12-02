using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoControler : MonoBehaviour
{
    [SerializeField]
    public float timeToWalk;

    [SerializeField]
    public float timeToEat;

    private float timeToWalkTimer;
    private float timeToEatTimer;

    private const int window = 3;

    Vector3 destionation;

    Animator animator;
    // Use this for initialization
    void Start()
    {
        timeToWalk = 10f;
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
        timeToWalkTimer += Time.deltaTime;

        if(timeToWalkTimer > timeToWalk)
        {
            animator.SetTrigger("goWalk");
            animator.SetBool("walking", true);
            destionation.x = Random.RandomRange(-10f, 10f);
            destionation.y = Random.RandomRange(-10f, 10f);
            timeToWalkTimer = 0f;
        }
        if (timeToEatTimer > timeToEat)
        {
            animator.SetBool("isHungry", true);
            timeToEatTimer = 0f;
        }

        if (animator.GetBool("walking"))
        {
            Transform transform = (Transform)gameObject.GetComponent<Transform>();
            Vector3 temp = transform.position;
            if(destionation.x - window > temp.x)
            {
                temp.x += Time.deltaTime;
            }
            else if(destionation.x + window < temp.x)
            {
                temp.x -= Time.deltaTime;
            }
            if (destionation.y - window > temp.y)
            {
                temp.y += Time.deltaTime;
            }
            else if(destionation.y + window < temp.y)
            {
                temp.y -= Time.deltaTime;
            }
        }
    }
}