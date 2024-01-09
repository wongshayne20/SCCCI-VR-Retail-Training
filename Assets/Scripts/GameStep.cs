using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStep: MonoBehaviour
{
    public List<GameObjective> allObjectives;

    public UnityEvent onStepBegin;
    public UnityEvent onStepComplete;

    public bool CheckComplete()
    {
        foreach(var curr in allObjectives)
        {
            if (!curr.CheckIsComplete())
                return false;
        }

        return true;
    }
}
