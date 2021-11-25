using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickToTarget : MonoBehaviour
{
    public float moveDuration = 1f;

    public void Execute(Unit target)
    {
        var ballRigidbody = GetComponent<Rigidbody>();

        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.useGravity = false;

        transform.SetParent(target.hands);
        transform.DOLocalMove(Vector3.zero, moveDuration);
    }
}
