using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public BuildingSettings[] buildingSettings;
    public int siteOffset = 1;
    public float RotationJitter = 0f;
    public bool autoUpdate;
    public GameObject citySpawnPoint;
    private List<Building> buildings = new List<Building>();
    private int pieceSize = 3;
    public int maxDim = 4;
    void Start()
    {
        LoadBuildingsWithRectanglePlots();
        UpdateHeight();
    }
    /*private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DeleteCity();
            LoadBuildingsWithRectanglePlots();
            UpdateHeight();
        }
    }*/
    public void LoadBuildingsWithRectanglePlots()
    {
        GameObject baseSpawnPoint = new GameObject("CitySpawn");
        baseSpawnPoint.transform.SetParent(citySpawnPoint.transform);
        baseSpawnPoint.transform.localPosition = Vector3.zero;
        List<RectInt> plots = GetComponent<CityPlotGenerator>().createPlots();
        foreach (RectInt plot in plots)
        {
            GameObject buildingSpawnPoint = new GameObject("BuildingSpawn");
            buildingSpawnPoint.transform.SetParent(baseSpawnPoint.transform);
            BuildingSettings s = buildingSettings[Random.Range(0, buildingSettings.Length)];
            int width = Mathf.Min(Mathf.Clamp(plot.width / pieceSize - siteOffset, 1, 1000),maxDim);
            int height = Mathf.Min(Mathf.Clamp(plot.height / pieceSize - siteOffset, 1, 1000), maxDim);

            s.SetSize(new Vector2Int(width, height));
            LoadBuilding(buildingSpawnPoint, s);
            int xpos = plot.x + plot.width - Random.Range(0, siteOffset) * pieceSize;
            int zpos = plot.y + plot.height - Random.Range(0, siteOffset) * pieceSize;


            buildingSpawnPoint.transform.localPosition = new Vector3(xpos, 0, zpos);
            buildingSpawnPoint.transform.rotation = Quaternion.Euler(0, Random.Range(0f,RotationJitter), 0);

        }

    }
    public void LoadBuilding(GameObject spawnPoint, BuildingSettings settings)
    {
        Building b = BuildingGenerator.Generate(settings);
        GetComponent<BuildingRenderer>().Render(b, spawnPoint);
        //Debug.Log(b.ToString());
    }

    public void DeleteCity()
    {
        Destroy(GameObject.Find("CitySpawn"));
        Destroy(GameObject.Find("PlotDebugger"));
    }

    public void UpdateHeight()
    {
        GameObject baseSpawn = GameObject.Find("CitySpawn");

        for (int i = 0; i < baseSpawn.transform.childCount; i++ ) {

            Transform buildingSpawnPoint = baseSpawn.transform.GetChild(i);
            RaycastHit hit;
            Physics.Raycast(buildingSpawnPoint.position + new Vector3(0f, 100f, 0f), -Vector3.up, out hit);
            //Debug.DrawRay(buildingSpawnPoint.position, -Vector3.up*100, Color.green, 30);
            //Debug.Log("Raycast origin: " + buildingSpawnPoint.position + ", distance: " + hit.distance);
            buildingSpawnPoint.position = new Vector3(buildingSpawnPoint.position.x, hit.point.y, buildingSpawnPoint.position.z);
        }
        
    }

}
