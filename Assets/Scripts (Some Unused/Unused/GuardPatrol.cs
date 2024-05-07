using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public bool isPatrolling;
    public float moveSpeed;
    public Rigidbody2D rigid;
    public Transform posOnGround;
    private bool doFlip;
    public LayerMask groundLM;
    //public Collider2D wallCollision;
  

    private void FixedUpdate()
    {
        if (isPatrolling)
        {
            doFlip = !Physics2D.OverlapCircle(posOnGround.position, 0.1f, groundLM);
        }
    }

    void Start()
    {
        isPatrolling = true;
    }

    
    void Update()
    {
        if (isPatrolling)
        {
            Patrolling();
        }
    }
    void Patrolling()
    {
        if (doFlip)
        {
            FlipDirection();
        }
        rigid.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rigid.velocity.y);
    }
    void FlipDirection()
    {
        isPatrolling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
        isPatrolling = true;
    }
}
