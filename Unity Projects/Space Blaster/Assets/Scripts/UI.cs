using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Health PlayerHealth;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Start(){
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        healthSlider.maxValue = PlayerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = "Score :" + scoreKeeper.GetScore();
        healthSlider.value = PlayerHealth.GetHealth();
    }
}
