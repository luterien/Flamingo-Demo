using UnityEngine;
using Cinemachine;

public class LockCamera : CinemachineExtension
{
    public float xPosition;
    public float yPosition;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = xPosition;
            pos.y = yPosition;
            state.RawPosition = pos;
        }
    }
}
