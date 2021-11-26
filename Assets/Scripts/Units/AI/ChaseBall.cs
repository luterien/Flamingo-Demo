using System.Collections;
using UnityEngine;

public class ChaseBall : MonoBehaviour
{
    public Transform mainBody;
    public Animator animator;

    public float movespeed;

    private Ball ball;

    private void Update()
    {
        if (ball != null)
        {
            var ballPos = ball.transform.position;

            var newPos = Vector3.MoveTowards(
                mainBody.position, 
                new Vector3(ballPos.x, mainBody.position.y, mainBody.position.z),
                movespeed * Time.deltaTime
            );

            if (Boundaries.OutOfBounds(newPos))
            {
                enabled = false;
                return;
            }

            mainBody.position = newPos;
        }
    }

    private void OnEnable()
    {
        ball = FindObjectOfType<Ball>();

        animator.SetBool("Moving", true);
    }

    private void OnDisable()
    {
        animator.SetBool("Moving", false);
    }
}
