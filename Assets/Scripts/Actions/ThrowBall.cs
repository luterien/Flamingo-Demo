using System;
using System.Collections;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public static event Action OnExecute;

    [Header("Refs")]
    public GameObject ballPrefab;

    private void Awake()
    {
        InputController.OnFingerUp += Execute;
    }

    public void Execute(Vector3 direction)
    {
        StartCoroutine(ShootBall(direction));
    }

    private IEnumerator ShootBall(Vector3 direction)
    {
        yield return new WaitForSeconds(0.5f);

        var player = UnitController.Instance.Current;

        if (player != null)
        {
            var ball = Instantiate(ballPrefab);
            ball.transform.position = player.ballSpawnPoint.position;
            ball.GetComponent<Ball>().Shoot(direction);

            OnExecute?.Invoke();
        }
    }
}