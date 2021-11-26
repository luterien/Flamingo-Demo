using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MSingleton<UnitController>
{
    public List<Unit> units;

    private Unit activeUnit;

    public Unit Current => activeUnit;
    public Unit NextUnit {
        get {
            var nextIndex = units.IndexOf(Current) + 1;
            if (nextIndex < units.Count)
                return units[nextIndex];

            return null;
        }
    }

    public void SwitchToNextUnit()
    {
        Unit newActiveUnit;

        if (activeUnit == null)
            newActiveUnit = units[0];
        else
            newActiveUnit = NextUnit;

        if (activeUnit != null)
            activeUnit.Deactivate();

        if (newActiveUnit != null)
        {
            activeUnit = newActiveUnit;
            activeUnit.ActivatePlayer();
        }
    }
}
