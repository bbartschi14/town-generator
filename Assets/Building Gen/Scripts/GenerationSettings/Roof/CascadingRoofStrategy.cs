using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

[CreateAssetMenu(menuName = "Building Generation/Roof/Cascading")]
public class CascadingRoofStrategy : RoofStrategy
{
    public RoofStrategy[] strategies;
    public bool useRandom;
    [Range(0,1)]
    public float randomChance;
    public override Roof GenerateRoof(BuildingSettings settings, RectInt bounds)
    {
        for (int i = 0; i < strategies.Length; i++)
        {
            if (Random.Range(0f,1f) > (1f-randomChance) && useRandom)
            {
                return new Roof((RoofType)Random.Range(0, 3));
            }
            Roof roof = strategies[i].GenerateRoof(settings, bounds);
            if (!roof.IsDefault)
            {
                return roof;
            }
        }

        return new Roof(RoofType.Peak);
    }
}
