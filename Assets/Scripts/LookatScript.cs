using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatScript : MonoBehaviour
{
    public Transform toWatch;

    // Update is called once per frame
    void Update()
    {
        WatchTarget();
    }

    public void SetWatchTarget(Transform newTarget)
    {
        toWatch = newTarget;
    }

    private void WatchTarget()
    {
        transform.LookAt(toWatch, Vector3.up);
    }
}
