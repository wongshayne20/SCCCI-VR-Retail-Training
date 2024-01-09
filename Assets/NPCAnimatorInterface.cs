using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorInterface : MonoBehaviour
{
    public Animator animator;

    public void SetWalkState(bool toSet)
    {
        animator.SetBool("IsWalking", toSet);
    }

    public void SetTrigger(string toSet)
    {
        animator.SetTrigger(toSet);
    }
}
