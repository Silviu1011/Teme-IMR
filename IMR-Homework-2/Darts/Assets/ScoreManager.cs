using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    UIManager manager;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        manager = FindObjectOfType<UIManager>();
    }

    public void addScore(int points) {
        score += points;
        manager.updateScore(score);
    }
}
