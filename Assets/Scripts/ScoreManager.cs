using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IListener
{
    private int score = 10;

    public Text ScoreText;

    void Start()
    {
        EventBus.Instance.AddListener(EventType.OBSTACLE_PASSED, this);
    }

    private void OnDestroy()
    {
        EventBus.Instance.AddListener(EventType.OBSTACLE_PASSED, this);
    }

    public void OnEvent(EventType eventType, Component sender, object param = null)
    {
        if (eventType == EventType.OBSTACLE_PASSED)
        {
            Debug.Log($"Hey, event was triggered!! parameters are {param} from {sender.name}");
            UpdateScore(10);
        }
    }

    //private void OnEnable()
    //{
    //    EventBus.PlayerPassedObstacle += HandleObstaclePassed;
    //    EventBus.ScoreChanged += UpdateScore;

    //}

    //private void OnDisable()
    //{
    //    EventBus.PlayerPassedObstacle += HandleObstaclePassed;
    //    EventBus.ScoreChanged += UpdateScore;

    //}

    private void HandleObstaclePassed()
    {
        Debug.Log("The player has passed obstacles");

    }

    private void UpdateScore(int score)
    {
        ScoreText.text += score;
        Debug.Log("score:" + score);
    }

}
