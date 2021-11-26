using System;
using System.Collections;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public static event Action OnExecute;

    [Header("Refs")]
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    [Space]
    public Animator animator;

    [Header("Settings")]
    public float throwAnimDuration;
    public float ballShootDelay;

    public void Execute(Vector3 direction)
    {
        StartCoroutine(ShootBall(direction));
        StartCoroutine(DisableSelf());
    }

    private IEnumerator ShootBall(Vector3 direction)
    {
        animator.SetTrigger("Throw");

        yield return new WaitForSeconds(ballShootDelay);

        GameObject ball;

        if (ballSpawnPoint.childCount > 0)
            ball = ballSpawnPoint.GetChild(0).gameObject;
        else
            ball = Instantiate(ballPrefab);

        ball.transform.SetParent(null);
        ball.transform.position = ballSpawnPoint.position;
        ball.GetComponent<Ball>().Shoot(direction);

        CameraController.Instance.SetFollowTarget(ball.transform);

        var nextUnit = UnitController.Instance.NextUnit;
        if (nextUnit != null)
            nextUnit.ActivateAI();

        OnExecute?.Invoke();
    }

    private IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(throwAnimDuration);
        enabled = false;
    }

    private void OnEnable()
    {
        InputController.OnFingerUp += Execute;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        InputController.OnFingerUp -= Execute;
    }
}