using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Instance.PostNotification(EventType.OBSTACLE_PASSED, this, 10);

        }
    }
}
