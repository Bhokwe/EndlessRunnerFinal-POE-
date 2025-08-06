using System;
using UnityEngine;

public static class EventBus 
{
    public static Action PlayerPassedObstacle;

    public static Action<int> ScoreChanged;
}
