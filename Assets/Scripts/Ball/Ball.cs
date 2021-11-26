using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody rBody;

    private void Update()
    {
        if (Boundaries.OutOfBounds(transform.position))
            StartCoroutine(EndGame());
    }

    public void Shoot(Vector3 direction)
    {
        var velocity = direction * speed;
        velocity.y = 1f;
        rBody.useGravity = true;
        rBody.isKinematic = false;
        rBody.velocity = velocity;
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.2f);
        GameController.Instance.EndGame();
    }
}