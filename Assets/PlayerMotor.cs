using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System;
using System.Collections;
public class PlayerMotor : MonoBehaviour
{
    public bool canmove = true;
    Vector2 direction;
    private Rigidbody2D rigidbody2D;
    private int canJump = 2;
    private bool canDash = true;
    public float maxSpeed = 10;
    public float stoppingForce = 5;
    public float speed = 10;
    public float jumpForce = 10;
    public Animator animator;
    public GameObject pierd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));

        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }

        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }

        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
      


    }
    private void Update()
    {
        animator.SetBool("Isjumping", MathF.Abs(rigidbody2D.linearVelocityY) > MathF.Abs(rigidbody2D.linearVelocityX));
        animator.SetFloat("Speed",MathF.Abs(rigidbody2D.linearVelocityX));
        if (rigidbody2D.linearVelocityX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Quaternion r = pierd.transform.rotation;
            r.z = 0;
            pierd.transform.rotation = r;
        }
        if (rigidbody2D.linearVelocityX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
           
            Quaternion r = pierd.transform.rotation;
            r.z = -180;
            pierd.transform.rotation = r;
        }

    }
    private void OnMove(InputValue value)
    {
        if (canmove)direction = value.Get<Vector2>();
    }
    private void OnSprint()
    {
        if (direction.x != 0)
        {
            canDash = false;
            rigidbody2D.AddForce(new Vector2(MathF.Sign(direction.x)*1000, 0));
            StartCoroutine(Timer(1, Resetdash));
            pierd.GetComponent<ParticleSystem>().Emit(30);
        }

    }
    private void Resetdash()
    {
        canDash = true;
    }
    IEnumerator Timer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
    private void Resetmove()
    {
        canmove = true;
        animator.SetBool("IsSpecial", false);
    }
    
    private void OnJump()
    {
        if (canJump>0 && canmove)
        {
            animator.SetBool("Isjumping", true);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump -= 1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Isjumping", false);
        canJump = 2;
    }
    private void OnInteract()
    {
        if (animator.GetBool("IsSpecial")) return;
        canmove = false;
        Debug.Log("pije piwo");
        StartCoroutine(Timer(1, Resetmove));
        animator.SetBool("IsSpecial", true);
        animator.SetInteger("Special", animator.GetInteger("Special") + 1);
    }

}