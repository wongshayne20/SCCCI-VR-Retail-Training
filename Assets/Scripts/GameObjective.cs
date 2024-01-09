using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjective : MonoBehaviour
{
    protected bool isComplete = false;

    public UnityEvent onComplete;

    public void SetIsComplete(bool toSet)
    {
        isComplete = toSet;

        if (isComplete)
            onComplete.Invoke();
    }
    
    public bool CheckIsComplete()
    {
        return isComplete;
    }
}
