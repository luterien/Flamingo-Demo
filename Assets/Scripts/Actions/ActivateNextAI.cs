using System.Collections;
using UnityEngine;

public class ActivateNextAI : MonoBehaviour
{
    private void Awake()
    {
        ThrowBall.OnExecute += Execute;
    }

    public void Execute()
    {
        var nextUnit = UnitController.Instance.NextUnit;
        if (nextUnit != null)
            nextUnit.ActivateAI();
    }
}