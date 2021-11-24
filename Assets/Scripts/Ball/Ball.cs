using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody rBody;

    public void Shoot(Vector3 direction)
    {
        var velocity = direction * speed;
        velocity.y = 1f;
        rBody.velocity = velocity;
    }
}