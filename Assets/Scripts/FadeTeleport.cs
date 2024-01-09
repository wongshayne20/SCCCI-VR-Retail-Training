using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTeleport : TeleportObjectScript
{
    public FadeScreen fadeScreen;

    public override void TeleportByPosition(Vector3 Destination)
    {
        StartCoroutine(TeleportRoutine(Destination));
    }

    public override void TeleportByTransform(Transform DestinationTrans)
    {
        StartCoroutine(TeleportRoutine(DestinationTrans.position));
    }

    IEnumerator TeleportRoutine(Vector3 Destination)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        
        toTeleport.transform.position = Destination;
        
        yield return new WaitForSeconds(1.0f);
        fadeScreen.FadeIn();
    }
}
