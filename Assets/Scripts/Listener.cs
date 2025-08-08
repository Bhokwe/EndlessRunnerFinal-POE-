using System.Diagnostics.Tracing;
using UnityEngine;

public class SimpleListener : MonoBehaviour, IListener
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventBus.Instance.AddListener(EventType.OBSTACLE_PASSED, this);

    }

    private void OnDestroy()
    {
        EventBus.Instance.AddListener(EventType.OBSTACLE_PASSED, this);
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnEvent(EventType eventType, Component sender, object param = null)
    {
        if (eventType == EventType.OBSTACLE_PASSED)
        {
            Debug.Log($"Hey, event was triggered!! parameters are {param} from {sender.name}");
        }
    }

}
