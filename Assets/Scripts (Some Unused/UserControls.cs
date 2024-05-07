using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserControls : MonoBehaviour
{

    private Animator animator;

    private bool jump = false;
    private float hValue = 0;
    //private float vValue = 0;
    private CharMovement character;

    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharMovement>();
    }

    public void Moving(InputAction.CallbackContext cont)
    {
        Vector2 move = cont.ReadValue<Vector2>();
        hValue = move.x;
    }
    public void Jumping(InputAction.CallbackContext cont)
    {
        jump = cont.performed; 
        //Vector2 jump = cont.ReadValue<Vector2>();
        //hValue = jump.y;

    }

    
    void Update()
    {
        animator.SetFloat("hValue", Mathf.Abs(hValue));
        //animator.SetFloat("vValue", Mathf.Abs(vValue));
    }

    private void FixedUpdate()
    {
        character.Move(hValue, jump);
        jump = false;
    }
}
