using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{  
    [SerializeField] int PlayerLives = 3;
    [SerializeField] int CollectCoins = 0;
    [SerializeField] TextMeshProUGUI Lives;
    [SerializeField] TextMeshProUGUI Score;

    TextMeshProUGUI Text;

   void  Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }   
   }
    void Start()
    {
        Lives.text = PlayerLives.ToString();
        Score.text = CollectCoins.ToString();
    }
    public void AddToScore(int points)
    {
        CollectCoins += points;
        Score.text = CollectCoins.ToString();
    }
    public void PlayerDeath()
    {
        if (PlayerLives > 1)
        {
           TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    void TakeLife()
    {
        PlayerLives--;
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
        Lives.text = PlayerLives.ToString();
    }
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }    
   
}
