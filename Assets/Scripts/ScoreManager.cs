using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private void OnEnable()
    {
        EventBus.PlayerPassedObstacle += HandleObstaclePassed;
        EventBus.ScoreChanged += UpdateScore;

    }

    private void OnDisable()
    {
        EventBus.PlayerPassedObstacle += HandleObstaclePassed;
        EventBus.ScoreChanged += UpdateScore;

    }
    
    private void HandleObstaclePassed()
    {
        Debug.Log("The player has passed obstacles");

    }

    private void UpdateScore()
    {
        score += points;
        Debug.Log("score:" +  score);
    }

}
