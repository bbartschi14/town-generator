using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    Vector2Int size;
    Wing[] wings;

    public Wing[] Wings { get => wings;}
    public Vector2Int Size { get => size;}

    public Building(int sizeX, int sizeY, Wing[] wings)
    {
        size = new Vector2Int(sizeX, sizeY);
        this.wings = wings;
    }
    public override string ToString()
    {
        string building = "Building:(" + size.ToString() + "; " + wings.Length + ")\n";
        foreach (Wing w in wings)
        {
            building += "\t" + w.ToString() + "\n";
        }
        return building;
    }
}
