using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] bool isPlayer;
   [SerializeField] int ScoreAdd =50;
   [SerializeField] ParticleSystem hitparticles;
   [SerializeField] int health =50;

   CameraShake cameraShake;
   [SerializeField] bool applyCameraShake;
   AudioManager audiomanager;
   ScoreKeeper score;
   LevelManager level;
   

   void Start()
   {
     cameraShake = Camera.main.GetComponent<CameraShake>();
     audiomanager = FindFirstObjectByType<AudioManager>();
     score = FindFirstObjectByType<ScoreKeeper>();
     level = FindFirstObjectByType<LevelManager>();
   }

   void OnTriggerEnter2D(Collider2D other) 
   {
      DamageDealer damageDealer = other.GetComponent<DamageDealer>();
      
      if(damageDealer != null)
      {
          TakeDamage(damageDealer.GetDamage());
          HitParticle();
          damageDealer.Hit();
          audiomanager.PlayDamageVFX();

          if(applyCameraShake){
            cameraShake.Play();
          }
      }
   }
   void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            die(); 
        }
    }

    void die(){
        if(isPlayer)
        {
            level.GameOver();
        }
        else
        {
           score.ModifyScore(ScoreAdd);
        }
         Destroy(gameObject);
    }

    void HitParticle()
    {
        if(hitparticles != null)
        {
           ParticleSystem particles = Instantiate(hitparticles, transform.position, Quaternion.identity);
           Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }

    }

    public int GetHealth()
    {
        return health;
    }
}
