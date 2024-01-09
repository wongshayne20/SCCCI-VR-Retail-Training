using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCPathFollowScript : MonoBehaviour
{
    public GameObject toMove;
    
    public Transform[] AllWaypoints;

    public int currentIndex = 0;

    public int destinationIndex;

    private bool isTravelling = false;

    public UnityEvent OnStartPathTravel;
    public UnityEvent OnPausePathTravel;

    public float MoveSpeed = 1.0f;

    private float p2PDistance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTravelling)
        {
            MoveToWaypoint();
        }
    }

    public void SetCurrentIndex(int toSet)
    {
        currentIndex = toSet;
    }

    private void MoveToWaypoint()
    {
        Vector3 DirectionVector = AllWaypoints[currentIndex + 1].position - AllWaypoints[currentIndex].position;

        //Rotate to face
        toMove.transform.rotation = Quaternion.LookRotation(DirectionVector, Vector3.up);

        //Move object
        float StarttoEndDist = DirectionVector.magnitude;
        p2PDistance = Mathf.Min(p2PDistance + MoveSpeed * Time.deltaTime, StarttoEndDist);

        toMove.transform.position = AllWaypoints[currentIndex].position + Mathf.Lerp(0.0f, 1.0f, p2PDistance/ StarttoEndDist) * DirectionVector;

        if(StarttoEndDist - p2PDistance <= Mathf.Epsilon)
            ArrivedAtWaypoint();

    }

    private void ArrivedAtWaypoint()
    {
        p2PDistance = 0.0f;


        ++currentIndex;

        if(currentIndex > AllWaypoints.Length)
        {
            isTravelling = false;
            return;
        }

        if(currentIndex == destinationIndex)
        {
            isTravelling = false;
            OnPausePathTravel.Invoke();
        }
    }

    public void StartPathTraveltoDestinationIndex(int targetDestination)
    {
        if(targetDestination <= currentIndex)
        {
            Debug.LogError("Target path index of " + targetDestination + "is past current path index of " + currentIndex);
            return;
        }

        destinationIndex = targetDestination;

        OnStartPathTravel.Invoke();
        isTravelling = true;
    }
}
