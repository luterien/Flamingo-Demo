using System;
using UnityEngine;

public class InputController : MSingleton<InputController>
{
    public static event Action OnFingerDown;
    public static event Action<Vector3> OnFingerUp;

    private bool fingerDown = false;

    private Vector3 MousePosition => new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y);

    public Vector3 MovementVector {
        get {
            if (!fingerDown)
                return Vector3.zero;
            return Vector3.Normalize(MousePosition - screenCenterPosition);
        }
    }

    private Vector3 screenCenterPosition;

    private void Start()
    {
        screenCenterPosition = new Vector3(Screen.width / 2, 0, 0);
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fingerDown = true;
            OnFingerDown?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnFingerUp?.Invoke(MovementVector);
            fingerDown = false;
        }
    }
}
