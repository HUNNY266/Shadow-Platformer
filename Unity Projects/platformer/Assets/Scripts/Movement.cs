using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float Jumpforce = 5f;
    [SerializeField] float ClimbSpeed = 5f;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Gun;
    Vector2 Move;
    Rigidbody2D rb;
    CapsuleCollider2D body;
    BoxCollider2D feet;
    Animator Animate;
    float gravityScaleAtStart;
    bool isAlive = true;

    AudioManager Audio;

       void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animate = GetComponent<Animator>();
        body = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
        feet = GetComponent<BoxCollider2D>();
        Audio = FindFirstObjectByType<AudioManager>();
    }

    
    void Update()
    {
        if (!isAlive){ return;}
       Run();
       flip();
       Climb();
       die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive){ return;}
        Move = value.Get<Vector2>();
        Debug.Log(Move);
    }
    void OnJump(InputValue value)
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return;}
           
        if (value.isPressed)
        {
            Audio.PlayJump();
            rb.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
        }
    }
    void Run()
    {
        Vector2 NewMove = new Vector2(Move.x * MoveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = NewMove;
        if (Move.x != 0)
        {
            Animate.SetBool("IsRuning", true);
        }
        else
        {
            Animate.SetBool("IsRuning", false);
        }
    }
    void flip()
    {
        bool PlayerHorizontal = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (PlayerHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }
    void Climb()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("climb")))
        {
            rb.gravityScale = gravityScaleAtStart;
             Animate.SetBool("IsClimbing", false);
            return;
        }
        rb.gravityScale = 0f;
          Vector2 ClimbMove = new Vector2(rb.linearVelocity.x, Move.y * ClimbSpeed);
        rb.linearVelocity = ClimbMove;
        bool PlayerVertical = Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon;
        Animate.SetBool("IsClimbing", PlayerVertical);
    }
    void OnAttack(InputValue value)
    {
        if (!isAlive){ return;}
        Instantiate(Bullet, Gun.position, transform.rotation);
    }
    void die()
    {
        if (body.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            StartCoroutine(DeathDelay());
            isAlive = false;
            Animate.SetTrigger("Die");
            rb.AddForce(new Vector2(10f, 20f), ForceMode2D.Impulse);
                
            FindObjectOfType<GameSession>().PlayerDeath();
        }
    }

    IEnumerator DeathDelay()
    {
        Audio.PlayDeath();
        yield return new WaitForSeconds(1f);
    }
}