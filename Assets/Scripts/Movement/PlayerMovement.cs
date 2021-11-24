using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    public Transform mainBody;
    public float movespeed;

    private InputController inputController;

    private void Awake()
    {
        inputController = InputController.Instance;
    }

    private void Update()
    {
        Move(inputController.MovementVector);
    }

    public void Move(Vector3 direction)
    {
        mainBody.position += movespeed * Time.deltaTime * direction;
    }
}