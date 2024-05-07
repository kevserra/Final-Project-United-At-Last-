using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private bool groundContact = false;
    [SerializeField] private Transform checkContact;
    [SerializeField] private LayerMask isItGround;
    const float checkRad = 0.2f;

    [Space]

    private Rigidbody2D rigid;
    [SerializeField] private float jumpingForce = 6.0f;

    [Header("Movement Settings")]

    [SerializeField] private float speed = 5.50f;
    private Vector2 veloRef = Vector2.zero;
    [Range(0, 0.3f)][SerializeField] private float smoothing = 0.05f;

    private bool flipLeft = false;
    private SpriteRenderer sprite;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Move(float move, bool jump)
    {
        Jumps(jump);
        Movement(move);
        CheckDir(move);
    }

    void CheckDir(float move)
    {
        if ((move > 0 && flipLeft) || (move < 0 && !flipLeft))
        {
            flipLeft = !flipLeft;
            sprite.flipX = flipLeft;       //---> to switch char direction
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }
    void GroundCheck()
    {
        Collider2D cold = Physics2D.OverlapCircle(checkContact.position, checkRad, isItGround);
        groundContact = (cold != null) ? true : false;
    }

    void Movement (float move)
    {
        Vector2 targetVelo = new Vector2(move * speed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelo, ref veloRef, smoothing);
    }

    void Jumps(bool jump)
    {
        if(jump && groundContact)
        {
            rigid.AddForce(Vector3.up * jumpingForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = (groundContact) ? Color.green : Color.cyan;
        Gizmos.DrawWireSphere(checkContact.position, checkRad);
    }


    void Update()
    {
        
    }
}
