using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Player passed the obstacle? Raise the event.
            EventBus.PlayerPassedObstacle?.Invoke();

            //Increase the score by 10
            EventBus.ScoreChanged?.Invoke(10);
        }
    }
}
