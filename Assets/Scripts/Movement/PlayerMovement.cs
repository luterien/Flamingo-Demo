using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [Header("Refs")]
    public Animator animator;
    public Transform mainBody;

    [Header("Settings")]
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

    public void Move(Vector3 moveVector)
    {
        mainBody.position += movespeed * Time.deltaTime * moveVector;
        animator.SetBool("Moving", moveVector != Vector3.zero);
    }
}
