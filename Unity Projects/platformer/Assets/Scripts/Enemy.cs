using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;
    Rigidbody2D rb;
       void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.linearVelocity = new Vector2(MoveSpeed, rb.linearVelocity.y);
    }
    void OnTriggerExit2D(Collider2D collision) 
    {
        MoveSpeed = -MoveSpeed;
        flipEnemy();
 }
    void flipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.linearVelocity.x)), 1f);
    }
}
