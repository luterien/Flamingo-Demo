using System.Collections;
using UnityEngine;

public class ThrowBallOnFingerRelease : MonoBehaviour
{
    [Header("Refs")]
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;

    private InputController inputController;
    private bool active = false;

    private Vector3 direction;

    private void Start()
    {
        inputController = InputController.Instance;
        inputController.OnFingerUp += Execute;
    }

    private void Update()
    {
        if (active)
        {

        }
    }

    private void Execute(Vector3 lastMovementVector)
    {
        direction = lastMovementVector;
        StartCoroutine(ShootBall());
    }

    private IEnumerator ShootBall()
    {
        yield return new WaitForSeconds(0.5f);
        var ball = Instantiate(ballPrefab);
        ball.transform.position = ballSpawnPoint.position;
        ball.GetComponent<Ball>().Shoot(direction);
    }
}