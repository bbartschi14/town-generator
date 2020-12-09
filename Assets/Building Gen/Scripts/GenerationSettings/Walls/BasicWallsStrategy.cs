using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Building Generation/Walls/Basic")]
public class BasicWallsStrategy : WallsStrategy
{
    public bool enableBalconies;
    public override Wall[] GenerateWalls(BuildingSettings settings, RectInt bounds, int level)
    {
        Wall[] walls = new Wall[(bounds.size.x + bounds.size.y) * 2];

        List<int> usedIndices = new List<int>();
        if (level == 0 || enableBalconies)
        {
            int doorIndex = Random.Range(0, walls.Length);
            usedIndices.Add(doorIndex);
            walls[doorIndex] = Wall.Door;
        }
        float percentWindows = .50f;
        int numWindows = (int)(walls.Length * percentWindows);

        for (int i = 0; i < numWindows; i++)
        {
            int windowIndex = Random.Range(0, walls.Length);
            while (usedIndices.Contains(windowIndex)) {
                windowIndex = Random.Range(0, walls.Length);
            }
            usedIndices.Add(windowIndex);
            walls[windowIndex] = Wall.Window;
        }

        return walls;
    }
}
