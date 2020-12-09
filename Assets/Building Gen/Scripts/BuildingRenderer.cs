using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRenderer : MonoBehaviour
{
    public Transform floorPrefab;
    public Transform patioPrefab;
    public Transform[] wallPrefab;
    public Transform[] roofPrefab;
    Transform bldgFolder;
    public Color[] bldgColors;
    private Color bldgColor;


    public void Render(Building bldg, GameObject spawnLocation)
    {
        bldgFolder = new GameObject("Building").transform;
        bldgFolder.transform.SetParent(spawnLocation.transform);
        //Debug.Log("Size: " + bldg.Size);
        //Debug.Log("Move: " + new Vector3((float)bldg.Size.x / 2 * 3, 0f, (float)bldg.Size.y / 2 * 3));
        
        bldgColor = bldgColors[UnityEngine.Random.Range(0, bldgColors.Length)];
        foreach (Wing wing in bldg.Wings)
        {
            RenderWing(wing);
        }
        
        bldgFolder.transform.Translate(new Vector3((float)bldg.Size.x / 2 * 3, 0f, (float)bldg.Size.y / 2 * 3));

    }

    private void RenderWing(Wing wing)
    {
        Transform wingFolder = new GameObject("Wing").transform;
        wingFolder.SetParent(bldgFolder);
        foreach (Story story in wing.Stories)
        {
            RenderStory(story, wing, wingFolder);
        }
        RenderRoof(wing, wingFolder);
    }



    private void RenderStory(Story story, Wing wing, Transform wingFolder)
    {
        Transform storyFolder = new GameObject("Story " + story.Level).transform;
        storyFolder.SetParent(wingFolder);
        for (int x = story.Bounds.min.x; x < story.Bounds.max.x; x++)
        {
            for (int y = story.Bounds.min.y; y < story.Bounds.max.y; y++)
            {
                PlaceFloor(x, y, story.Level, storyFolder);

                //south wall
                if (y == story.Bounds.min.y)
                {
                    int wall = (int)story.Walls[x - story.Bounds.min.x];
                    PlaceSouthWall(x, y, story.Level, storyFolder, wall);
                }

                //east wall
                if (x == story.Bounds.min.x + story.Bounds.size.x - 1)
                {
                    int wall = (int)story.Walls[story.Bounds.size.x + y - story.Bounds.min.y];
                    PlaceEastWall(x, y, story.Level, storyFolder, wall);
                }

                //north wall
                if (y == story.Bounds.min.y + story.Bounds.size.y - 1)
                {
                    int wall = (int)story.Walls[story.Bounds.size.x * 2 + story.Bounds.size.y - (x - story.Bounds.min.x + 1)];
                    PlaceNorthWall(x, y, story.Level, storyFolder, wall);
                }

                //west wall
                if (x == story.Bounds.min.x)
                {
                    int wall = (int)story.Walls[(story.Bounds.size.x + story.Bounds.size.y) * 2 - (y - story.Bounds.min.y + 1)];
                    PlaceWestWall(x, y, story.Level, storyFolder, wall);
                }


            }
        }
    }

    private void PlaceFloor(int x, int y, int level, Transform storyFolder)
    {
        Transform f = Instantiate(floorPrefab, storyFolder.TransformPoint(new Vector3(x * -3f, 0f + level * 2.5f, y * -3f)), Quaternion.identity);
        f.SetParent(storyFolder);
    }

    private void PlaceSouthWall(int x, int y, int level, Transform storyFolder, int wall)
    {
        Transform w = Instantiate(
            wallPrefab[wall],
            storyFolder.TransformPoint(
                new Vector3(
                    x * -3f,
                    0.3f + level * 2.5f,
                    y * -3f - 0.5f
                    )
                ),
            Quaternion.Euler(0, 90, 0));
        w.SetParent(storyFolder);

        if (wall == 2)
        {
            Transform f = Instantiate(patioPrefab, storyFolder.TransformPoint(
                new Vector3(
                    x * -3f -3f,
                    0f + level * 2.5f,
                    (y) * -3f - 0.5f + 1f + 2.5f
                    )
                ),
            Quaternion.Euler(0, 270, 0));
            f.SetParent(storyFolder);
        }

    }

    private void PlaceEastWall(int x, int y, int level, Transform storyFolder, int wall)
    {
        Transform w = Instantiate(
            wallPrefab[wall],
            storyFolder.TransformPoint(
                new Vector3(
                    x * -3f - 2.5f,
                    0.3f + level * 2.5f,
                    y * -3f
                    )
                ),
            Quaternion.identity);
        w.SetParent(storyFolder);

        if (wall == 2)
        {
            Transform f = Instantiate(patioPrefab, storyFolder.TransformPoint(
                new Vector3(
                    (x) * -3f - 6f,
                    0f + level * 2.5f,
                    y * -3f - 3f
                    )
                ),
            Quaternion.Euler(0, 180, 0));
            f.SetParent(storyFolder);
        }
    }

    private void PlaceNorthWall(int x, int y, int level, Transform storyFolder, int wall)
    {
        Transform w = Instantiate(wallPrefab[wall], storyFolder.TransformPoint( new Vector3(x * -3f, 0.3f + level * 2.5f, y * -3f - 3f ) ),
            Quaternion.Euler(0, 90, 0));
        w.SetParent(storyFolder);

        if (wall == 2)
        {
            Transform f = Instantiate(patioPrefab, storyFolder.TransformPoint(new Vector3(x * -3f, 0f + level * 2.5f, (y+1) * -3f - 3f)),
            Quaternion.Euler(0, 90, 0));
            f.SetParent(storyFolder);
        }
    }

    private void PlaceWestWall(int x, int y, int level, Transform storyFolder, int wall)
    {
        Transform w = Instantiate(
            wallPrefab[wall],
            storyFolder.TransformPoint(
                new Vector3(
                    x * -3f,
                    0.3f + level * 2.5f,
                    y * -3f
                    )
                ),
            Quaternion.identity);
        w.SetParent(storyFolder);

        if (wall == 2)
        {
            Transform f = Instantiate(patioPrefab, storyFolder.TransformPoint(
                new Vector3(
                    (x-1) * -3f,
                    0f + level * 2.5f,
                    (y) * -3f
                    )
                ),
            Quaternion.identity);
            f.SetParent(storyFolder);
        }
    }

    private void RenderRoof(Wing wing, Transform wingFolder)
    {
        if (wing.GetRoof.IsScaled)
        {
            //Debug.Log("Placing with scale " + new Vector3((float)wing.Bounds.max.x, 1.0f, (float)wing.Bounds.max.y));
            PlaceRoof(wing.Bounds.max.x - 1, wing.Bounds.min.y, wing.Stories.Length, wingFolder, wing.GetRoof.Type, wing.GetRoof.Direction, 
                new Vector3((float)wing.Bounds.max.y, 1.0f, (float)wing.Bounds.max.x));
            return;
        }
        for (int x = wing.Bounds.min.x; x < wing.Bounds.max.x; x++)
        {
            for (int y = wing.Bounds.min.y; y < wing.Bounds.max.y; y++)
            {
                for (int i = 0; i < wing.Stories.Length; i++)
                {
                    Story s = wing.Stories[i];
                    if (i < wing.Stories.Length - 1)
                    {
                        if (!wing.Stories[i + 1].Bounds.Contains(new Vector2Int(x, y)))
                        {
                            PlaceRoof(x, y, s.Level + 1, wingFolder, wing.GetRoof.Type, wing.GetRoof.Direction, new Vector3(1.0f, 1.0f, 1.0f));
                            break;
                        }
                    } else if (s.Level == wing.Stories.Length-1)
                    {
                        PlaceRoof(x, y, s.Level + 1, wingFolder, wing.GetRoof.Type, wing.GetRoof.Direction, new Vector3(1.0f, 1.0f, 1.0f));
                        break;
                    }

                }
            }
        }
    }

    private void PlaceRoof(int x, int y, int level, Transform wingFolder, RoofType type, RoofDirection direction, Vector3 scale)
    {
        Transform r;
        r = Instantiate(
            roofPrefab[(int)type],
            wingFolder.TransformPoint(
                new Vector3(
                        x * -3f + rotationOffset[(int)direction].x,
                        level * 2.5f + (type == RoofType.Point ? -0.3f : 0f),
                        y * -3f + rotationOffset[(int)direction].z
                    )
                ),
            Quaternion.Euler(0f, rotationOffset[(int)direction].y, 0f)
            );
        r.localScale = new Vector3(scale.x, Mathf.Min(Mathf.Min(scale.x, scale.z),2f), scale.z);
        r.SetParent(wingFolder);
        Material[] materials = r.GetChild(0).GetComponent<MeshRenderer>().materials;
        if (type == RoofType.Slope)
        {
            materials[2].SetColor("_Color", bldgColor);
        } else if (type == RoofType.Point)
        {
            materials[1].SetColor("_Color", bldgColor);
        } else if (type == RoofType.Peak)
        {
            materials[3].SetColor("_Color", bldgColor);
        }
    }

    Vector3[] rotationOffset = {
        new Vector3 (-3f, 270f, 0f),
        new Vector3 (0f, 0f, 0f),
        new Vector3 (0f, 90, -3f),
        new Vector3 (-3f, 180, -3f)
    };
}