using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float deadAtXSeconds = 3f;
    float GravityAtStart;
    bool IsAlive = true;
    float timerTillDeath = 0;

    Vector2 MoveInput;

    Rigidbody2D myRigidBody;
    Animator MyAnimator;
    BoxCollider2D Collider;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        GravityAtStart = myRigidBody.gravityScale;
    }


    void Update()
    {
        if (!IsAlive)
        {
            timerTillDeath += Time.deltaTime;
            if (timerTillDeath >= deadAtXSeconds)
            {
                SceneManager.LoadScene("End1");
            }
        }
        if (!IsAlive) { return; }
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        if (!IsAlive) { return; }
        MoveInput = value.Get<Vector2>();
        Debug.Log(MoveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(MoveInput.x * playerSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool PlayerHZMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        MyAnimator.SetBool("IsRunning", PlayerHZMoving);
        if (PlayerHZMoving)
        {
            //play sfx on repeat
        }
    }
    void FlipSprite()
    {
        bool PlayerHZMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (PlayerHZMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bob")
        {
            IsAlive = false;
        }
    }
}
