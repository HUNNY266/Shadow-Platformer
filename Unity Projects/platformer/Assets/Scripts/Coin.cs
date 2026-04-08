using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int CoinValue = 100;
    AudioManager Audio; 
   void OnTriggerEnter2D(Collider2D other) 
   {
      if (other.CompareTag("Player"))
      {
        FindObjectOfType<GameSession>().AddToScore(CoinValue);
        Audio = FindFirstObjectByType<AudioManager>();
        Audio.PlayCoin();
        Destroy(gameObject);
      }
    
   }
}
