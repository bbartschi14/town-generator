using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story 
{
    RectInt bounds;
    int level;
    Wall[] walls;

    public int Level { get => level; }
    public RectInt Bounds { get => bounds; }

    public Wall[] Walls { get => walls; }

    public Story(int level, Wall[] walls, RectInt bounds)
    {
        this.bounds = bounds;
        this.level = level;
        this.walls = walls;
    }

    public override string ToString()
    {
        string story = "Story " + level + ":\n";
        story += "\t\tWalls: ";
        foreach (Wall w in walls)
        {
            story += w.ToString() + ", ";
        }
        return story;
    }
}
