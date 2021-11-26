using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MSingleton<CameraController>
{
    public CinemachineVirtualCamera cam;

    public void SetFollowTarget(Transform target)
    {
        cam.Follow = target;
    }

    public void Deactivate()
    {
        cam.enabled = false;
    }
}