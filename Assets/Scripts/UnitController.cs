using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MSingleton<UnitController>
{
    public List<Unit> units;

    public Unit activeUnit;

    public void SwitchToNextUnit()
    {
        activeUnit = units[0];
        activeUnit.SetPlayer();
    }


}
