using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CityGenerator))]
public class CityGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CityGenerator cityGenerator = (CityGenerator)target;

        if (DrawDefaultInspector())
        {
            if (cityGenerator.autoUpdate)
            {
                cityGenerator.DeleteCity();
                cityGenerator.LoadBuildingsWithRectanglePlots();
            }

        }

        if (GUILayout.Button("Generate"))
        {
            cityGenerator.DeleteCity();
            cityGenerator.LoadBuildingsWithRectanglePlots();
        }

        if (GUILayout.Button("Update Height"))
        {
            cityGenerator.UpdateHeight();
        }

    }
}
