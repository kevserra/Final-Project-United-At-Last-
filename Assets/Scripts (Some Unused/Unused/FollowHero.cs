using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowHero : MonoBehaviour
{
    private Animator princessAnim;

    [Header("AI Follow Settings")]
    [Space]
    public float speed;
    public float offsetDistance;
    private Transform princess;

    private bool flipLeft = false;
    private SpriteRenderer sprite;

    public bool didCollide;


    //private Rigidbody2D rigid;
    //private Vector2 veloRef = Vector2.zero;
    //[Range(0, 0.3f)] [SerializeField] private float smoothing = 0.05f;
    //private float hValueWP = 0;
    //private CharMovement character;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !didCollide)
        {
            didCollide = true;
            FollowYourSaviour();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        didCollide = false;
    }

    void FollowYourSaviour()
    {
        if (Vector2.Distance(transform.position, princess.position) > offsetDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, princess.position, speed * Time.deltaTime);
        }
    }

    public void Move(float move)
    {
        CheckDirection(move);
    }

    void CheckDirection(float move)
    {
        if ((move > 0 && flipLeft) || (move < 0 && !flipLeft))
        {
            flipLeft = !flipLeft;
            sprite.flipX = flipLeft;       
        }
    }

  

    void Start()
    {
        princess = GetComponent<Transform>();
        princessAnim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
   
}
