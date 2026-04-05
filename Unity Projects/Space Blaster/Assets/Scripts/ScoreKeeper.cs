using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int Score = 0;

    static ScoreKeeper instance;

    void Awake(){
        ManageAudioSingleton();
    }

    void ManageAudioSingleton()
    {
        // int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore(){
        return Score;
    }

    public void ModifyScore(int scoreToadd)
    {
        Score +=scoreToadd;
        Score = Mathf.Clamp(Score, 0, int.MaxValue);
        // print(Score);
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
