using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Building Generation/Roof/Scaled")]

public class ScaledRoofStrategy : RoofStrategy
{
    public override Roof GenerateRoof(BuildingSettings settings, RectInt bounds)
    {
        if (bounds.size.x > 1 && bounds.size.y > 1)
        {
            Roof roof = new Roof(RoofType.Peak);
            roof.IsScaled = true;
            return roof;
        }
        else
        {
            Roof roof = new Roof(RoofType.Peak);
            roof.IsDefault = true;
            return roof;
        }
    }
}
