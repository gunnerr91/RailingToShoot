using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;

    int score;
    Text scoreTextComponent;

    void Start()
    {
        scoreTextComponent = GetComponent<Text>();
        scoreTextComponent.text = score.ToString();
    }

    public void UpdateScore()
    {
        scoreTextComponent.text = (score += scorePerHit).ToString();
    }
}
