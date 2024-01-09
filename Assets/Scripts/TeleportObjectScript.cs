using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectScript : MonoBehaviour
{
    public GameObject toTeleport;

    public virtual void TeleportByPosition(Vector3 Destination)
    {
        toTeleport.transform.position = Destination;
    }

    public virtual void TeleportByTransform(Transform DestinationTrans)
    {
        toTeleport.transform.position = DestinationTrans.transform.position;
    }
}
