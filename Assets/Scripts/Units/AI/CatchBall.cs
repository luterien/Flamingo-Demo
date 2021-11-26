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

        var chaseComponent = transform.parent.GetComponent<ChaseBall>();
        chaseComponent.enabled = false;

        CameraController.Instance.SetFollowTarget(sourceUnit.transform);

        StartCoroutine(TakeOver());
    }

    private IEnumerator TakeOver()
    {
        yield return new WaitForSeconds(1.5f);

        sourceUnit.model.rotation = Quaternion.identity;
        UnitController.Instance.SwitchToNextUnit();
    }
}
