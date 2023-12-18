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
    bool poisoned = false;
    float timerTillDeath = 0;
    float hasMask = 0;
    bool hasWorm = false;

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
        if (hasMask == 1)
        {
            MyAnimator.SetTrigger("HasMask");
        }
        if (!IsAlive)
        {
            timerTillDeath += Time.deltaTime;
            if (timerTillDeath >= deadAtXSeconds)
            {
                SceneManager.LoadScene("End1");
            }
        } if (poisoned)
        {
            timerTillDeath += Time.deltaTime;
            if (timerTillDeath>= deadAtXSeconds)
            {
                SceneManager.LoadScene("End3");
            }
        }
        if (!IsAlive) { return; }
        Run();
        FlipSprite();
        hasMask = GetComponent<Money>().mask;
        hasWorm = GetComponent<Money>().worm;
    }

    void OnMove(InputValue value)
    {
        if (!IsAlive || poisoned) { return; }
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
        if (collision.tag == "gas" && hasMask < 1)
        {
            poisoned = true;
        }
        if (collision.tag == "Escape1")
        {
            SceneManager.LoadScene("End4");
        }
        if (collision.tag == "Escape2" && hasWorm)
        {
            SceneManager.LoadScene("End2");
        }
    }
}
