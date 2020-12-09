using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingDemo))]
public class BuildingDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BuildingDemo buildingDemo = (BuildingDemo)target;

        if (DrawDefaultInspector()) { 
            if (buildingDemo.autoUpdate)
            {
                buildingDemo.DeleteBuilding();
                buildingDemo.LoadBuilding();
            }
        
        }

        if (GUILayout.Button("Generate"))
        {
            buildingDemo.DeleteBuilding();
            buildingDemo.LoadBuilding();
        }

    }
}
