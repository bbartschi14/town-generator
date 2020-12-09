using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building Generation/Building Settings")]
public class BuildingSettings : ScriptableObject
{
    public Vector2Int buildingSize;
    public int buildingHeight = 1;
    public int randomHeightRange = 1;
    public int randomSizeRange = 1;

    public WingsStrategy wingsStrategy;
    public WingStrategy wingStrategy;
    public StoriesStrategy storiesStrategy;
    public StoryStrategy storyStrategy;
    public WallsStrategy wallsStrategy;
    public RoofStrategy roofStrategy;
    public bool randomHeight;
    public bool randomSize;
    public Vector2Int Size { get  { return buildingSize; } }
    public int Height()
    {
        if (randomHeight)
        {
            return Random.Range(buildingHeight, buildingHeight + randomHeightRange);
        }
        else
        {
            return buildingHeight;
        }
        
    }

    public void SetSize(Vector2Int size)
    {
        if (randomSize)
        {
            size.x = Random.Range(size.x, size.x + randomSizeRange);
            size.y = Random.Range(size.y, size.y + randomSizeRange);
        }
        buildingSize = size;
    }

    public void SetHeight(int height)
    {
        
            buildingHeight = height;
        
    }
}
