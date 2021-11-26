using System.Collections;
using UnityEngine;

public class GameController : MSingleton<GameController>
{
    private InputController inputController;
    private UnitController unitController;
    private CameraController cameraController;

    private void Awake()
    {
        inputController = InputController.Instance;
        unitController = UnitController.Instance;
        cameraController = CameraController.Instance;
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);

        inputController.enabled = true;
        unitController.SwitchToNextUnit();
    }

    public void EndGame()
    {
        unitController.DeactivateAll();
        cameraController.Deactivate();
    }
}
