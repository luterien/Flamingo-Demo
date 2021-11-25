using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBall : MonoBehaviour
{
    public Unit sourceUnit;
    public Animator animator;

    private DetectCollision detectCollision;

    private void Awake()
    {
        detectCollision = GetComponent<DetectCollision>();
        detectCollision.OnDetect += HandleDetection;
    }

    private void HandleDetection(Collider collider)
    {
        collider.GetComponent<StickToTarget>().Execute(sourceUnit);

        DoCatch();
    }

    private void DoCatch()
    {
        animator.SetTrigger("Catch");
    }
}
