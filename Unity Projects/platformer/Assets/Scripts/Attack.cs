using UnityEngine;

public class Attack : MonoBehaviour
{
    Rigidbody2D rb;
    Movement player;
    float xspeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<Movement>();
        xspeed = player.transform.localScale.x *20f;
    }

    
    void Update()
    {
        rb.linearVelocity = new Vector2(xspeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject, 1f);
    }
}
