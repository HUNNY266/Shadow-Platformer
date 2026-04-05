using UnityEngine;
using TMPro;

public class UiFinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FinalScoreText;
    ScoreKeeper FinalScore;
   
   void Awake()
    {
        FinalScore = FindFirstObjectByType<ScoreKeeper>();
    }
    void Start()
    {
        FinalScoreText.text = FinalScore.GetScore().ToString();
    }
}
