using System;
using System.Collections.Generic;
using UnityEngine;


public enum EventType
{
    OBSTACLE_PASSED,
    COIN,
    SPEED_BOOST, 
    JUMP_PAD
}

public interface IListener
{
    void OnEvent(EventType OBSTACLE_PASSED, Component sender, object param = null);
}

public class EventBus : MonoBehaviour
{
    public static EventBus Instance;


    private Dictionary<EventType, List<IListener>> listeners = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddListener(EventType eventType, IListener listener)
    {
        if (listener == null) return;


        if (!listeners.TryGetValue(eventType, out var listenList))
        {
            listenList = new List<IListener>();
            listeners[eventType] = listenList;
        }

        if (!listenList.Contains(listener))
        {
            listenList.Add(listener);
        }


    }

    public void PostNotification(EventType eventType, Component sender, object param = null)
    {
        if (!listeners.TryGetValue(eventType, out var listenList)) return;

        for (int i = listenList.Count - 1; i >= 0; i--)
        {
            listenList[i]?.OnEvent(eventType, sender, param);
        }

    }

    public void RemoveListener(EventType eventType, IListener listener)
    {
        if (listeners.TryGetValue(eventType, out var listenList))
        {
            listenList.Remove(listener);

            //if its the last listener, remove the event
            if (listenList.Count == 0)
            {
                listeners.Remove(eventType);
            }
        }
    }
}


