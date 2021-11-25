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

        var ball = Instantiate(ballPrefab);
        ball.transform.position = ballSpawnPoint.position;
        ball.GetComponent<Ball>().Shoot(direction);

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
        InputController.OnFingerUp -= Execute;
    }
}