using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float walkAcceleration = 75;
    public float airAcceleration = 30;
    public float groundDeceleration = 70;
    public float jumpHeight = 4;

    private Rigidbody2D body;
    private Animator animator;
    private CharacterController controller;
    BoxCollider2D boxCollider;
    private Vector2 velocity;
    private bool grounded;

    //Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    //  Update is called once per frame
    void Update()
    {
        Physics2D.SetLayerCollisionMask(10, 8);
        transform.Translate(velocity * Time.deltaTime);
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isMoving = false;
        if (grounded)
        {
            velocity.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        float accelaration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;
        if (moveInput != 0)
        {   
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, accelaration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
        grounded = false;
        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider) continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
            if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0) grounded = true;
        }
        animator.SetFloat("X", velocity.x);
        animator.SetBool("isMoving", System.Math.Abs(velocity.x) > 0 ? true : false);
        animator.SetBool("isJumping", !grounded);
        ////Vector2 direction = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //bool isMoving = false;
        //if ((direction.x > 0 || direction.y > 0) || (direction.x < 0 || direction.y < 0))
        //{
        //    isMoving = true;
        //    //body.MovePosition(direction * speed * Time.deltaTime);
        //    body.position += (direction * speed * Time.deltaTime);

        //    animator.SetFloat("X", direction.x);
        //    animator.SetFloat("Y", direction.y);
        //}
        //animator.SetBool("isMoving", isMoving);

    }
    //public void SetDirectionalInput(Vector2 input)
    //{
    //    dire
    //}
    //private void Awake()
    //{

    //}

    //private void FixedUpdate()
    //{

    //}
}
