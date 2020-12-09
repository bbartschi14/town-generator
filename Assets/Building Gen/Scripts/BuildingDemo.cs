using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDemo : MonoBehaviour
{
    public BuildingSettings[] settingsArray;
    [Range(1,20)]
    public int width;

    [Range(1, 20)]
    public int depth;
    [Range(1, 20)]
    public int height;
    public bool autoUpdate;
    public GameObject spawnPoint;
    private BuildingSettings settings;
    public float frames = 35;
    public AnimationCurve animCurve;
    public ParticleSystem explosionSystem;
    IEnumerator currentCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        LoadBuilding();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DeleteBuilding();
            LoadBuilding();
        } 
    }
    public void LoadBuilding()
    {
        settings = settingsArray[Random.Range(0, settingsArray.Length)];
        SetSize(new Vector2Int(width, depth));
        SetHeight(height);
        Building b = BuildingGenerator.Generate(settings);
        GetComponent<BuildingRenderer>().Render(b,spawnPoint);
        explosionSystem.Play();
        currentCoroutine = LoadAnimation();
        StartCoroutine(currentCoroutine);
        //Debug.Log(b.ToString());
    }

    public void DeleteBuilding()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        var bldg = GameObject.Find("Building");//transform.GetChild(0);
        bldg.transform.parent = null;
        Destroy(bldg);
    }

    public void SetSize(Vector2Int size)
    {
        settings.SetSize(size);
    }

    public void SetHeight(int height)
    {
        settings.SetHeight(height);
    }

    IEnumerator LoadAnimation()
    {
        Transform building = spawnPoint.transform.GetChild(0);
        
        for (int i = 0; i < frames + 1; i++)
        {
            float value = animCurve.Evaluate(i / frames);
            building.localScale = Vector3.LerpUnclamped(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f), value);
            yield return null;
        }
        yield return null;
    }
}
