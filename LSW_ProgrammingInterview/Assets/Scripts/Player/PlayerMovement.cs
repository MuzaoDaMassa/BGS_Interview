using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Vector2 moveDirection;

    private Rigidbody2D rb2d;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontal, vertical);

        playerAnimator.SetFloat("horizontal", horizontal);
        playerAnimator.SetFloat("vertical", vertical);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2d.velocity = moveDirection * speed;
    }
}
