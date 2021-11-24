using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MSingleton<UnitController>
{
    public List<Unit> units;

    private Unit activeUnit;

    public Unit Current => activeUnit;
    public Unit NextUnit => activeUnit;

    public void SwitchToNextUnit()
    {
        activeUnit = units[0];
        activeUnit.ActivatePlayer();
    }
}
