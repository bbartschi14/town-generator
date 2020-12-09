using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof 
{
    RoofType type;
    RoofDirection direction;
    bool isScaled;
    bool isDefault;
    public RoofType Type { get => type; }
    public RoofDirection Direction { get => direction; }
    public bool IsScaled { get => isScaled; set => isScaled = value; }
    public bool IsDefault { get => isDefault; set => isDefault = value; }

    public Roof(RoofType type = RoofType.Peak, RoofDirection direction = RoofDirection.North)
    {
        this.type = type;
        this.direction = direction;
    }

    public override string ToString()
    {
        return "Roof: " + type.ToString() + ((type == RoofType.Peak || type == RoofType.Slope) ? ", " + direction.ToString() : "");
    }
}

public enum RoofType
{
    Point,
    Peak,
    Slope,
    Flat
}

public enum RoofDirection
{
    North, // +y
    East,  // +x
    South, // -y
    West   // -x
}