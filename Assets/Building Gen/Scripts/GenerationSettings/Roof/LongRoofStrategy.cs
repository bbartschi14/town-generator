using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building Generation/Roof/Long")]
public class LongRoofStrategy : RoofStrategy
{
    public override Roof GenerateRoof(BuildingSettings settings, RectInt bounds)
    {
        if (bounds.size.x < bounds.size.y)
        {
            Roof roof = new Roof(RoofType.Peak);
            roof.IsDefault = true;
            return roof;
        }
        else
        {
            return new Roof(RoofType.Peak, RoofDirection.East);
        }
    }
}
