using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerboxObjective : GameObjective
{
    public enum ColliderType
    {
        ENTER,
        EXIT,
        STAY
    }
    
    public string[] tagsToAccept;
    public float stayDuration;
    private float stayTimer = 0.0f;

    public ColliderType colliderCheckType;

    public UnityEvent TriggerEnterEvent;
    public UnityEvent TriggerExitEvent;
    public UnityEvent TriggerStayEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool VetTags(string toVet)
    {
        foreach(var curr in tagsToAccept)
        {
            if (curr == toVet)
                return true;
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(VetTags(other.tag))
        {
            TriggerEnterEvent.Invoke();

            if (colliderCheckType != ColliderType.ENTER)
                return;

            SetIsComplete(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (VetTags(other.tag))
        {
            TriggerExitEvent.Invoke();

            stayTimer = 0.0f;

            if (colliderCheckType == ColliderType.EXIT)
            {
                SetIsComplete(true);

            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (VetTags(other.tag))
        {
            TriggerStayEvent.Invoke();

            if (colliderCheckType != ColliderType.STAY)
                return;

            stayTimer += Time.deltaTime;

            if (stayTimer > stayDuration)
            {
                SetIsComplete(true);
            }
        }
    }
}
