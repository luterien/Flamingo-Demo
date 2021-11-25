using System.Collections;
using UnityEngine;

public class BoxCheck : DetectCollision
{
    [Header("Properties")]
    public LayerMask targetLayer;
    [Space]
    public Vector3 boxSize = Vector3.one;
    [Space]
    public bool deactivateOnDetect = false;

    public override void Execute()
    {
        bool disable = false;

        Collider[] collidersHit = Physics.OverlapBox(
            transform.position, boxSize / 2, Quaternion.identity, targetLayer);

        foreach (var collider in collidersHit)
        {
            TriggerDetection(collider);
            disable = true;
        }

        if (disable && deactivateOnDetect)
            enabled = false;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, boxSize);
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, boxSize);
    }
}