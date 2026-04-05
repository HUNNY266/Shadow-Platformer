using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
   [Header("Base Variables")]
   [SerializeField] GameObject Projectile;
   [SerializeField] float ProjectileSpeed = 10f;
   [SerializeField] float Projectilelife = 5f;
   [SerializeField] float fireRate = 0.2f;

   [Header("AI variables")]
   Coroutine FireCoroutine;
   [SerializeField] bool useAI;
   [SerializeField] float MinimumFireRate= 0.2f;
   [SerializeField] float FireVariance = 0f;

   [HideInInspector]public bool isFiring;
   AudioManager audio;

   void Start() 
   {
      audio = FindFirstObjectByType<AudioManager>();
     if(useAI){
        isFiring=true;
     }
   }
   void Update() 
   {
     Fire();
   }

   void Fire()
   {
     if (isFiring && FireCoroutine == null)
     {
        FireCoroutine = StartCoroutine(FiringMechanism());
     }
     else if(!isFiring && FireCoroutine != null)
     {
        StopCoroutine(FireCoroutine);
        FireCoroutine = null;
     }
   }

   IEnumerator FiringMechanism()
   {
      while(true)
      {
         GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
         projectile.transform.rotation = transform.rotation;
         Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
         rb.linearVelocity = transform.up*ProjectileSpeed;
         Destroy(projectile,Projectilelife);
         float waitTime = Random.Range(fireRate - FireVariance, fireRate + FireVariance);
         waitTime= Mathf.Clamp(waitTime, MinimumFireRate, float.MaxValue);
         audio.PlayShootingVFX();
        yield return new WaitForSeconds(waitTime); 
      }
   }

}
