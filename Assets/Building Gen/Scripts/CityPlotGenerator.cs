using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPlotGenerator : MonoBehaviour
{
    public RectInt cityBounds;
    public int minSize = 10;
    List<RectInt> plots;
    public bool DisplayPlots = true;
    public int maxSize = 30;
    public List<RectInt> Plots { get => plots; }

    private void Start()
    {
        /*plots = createPlots();
        if (DisplayPlots)
        {
            DebugPlots(plots);
        }*/
    }
    public List<RectInt> createPlots()
    {
        List<RectInt> plots = new List<RectInt>();
        plots.Add(cityBounds);
        bool overMaxSize = true;
        while (overMaxSize)
        {
            overMaxSize = false;
            //int indexToSplit = Random.Range(0, plots.Count - 1);
            //RectInt plotToSplit = plots[indexToSplit];
            //int direction = Random.Range(0, 2); // 0 vertical split, 1 horizontal split
            List<RectInt> newPlots = new List<RectInt>();

            foreach (RectInt plot in plots) {
                if (plot.width > maxSize && plot.height > maxSize)
                {
                    int direction = Random.Range(0, 2);
                    List<RectInt> subPlots = splitPlot(plot, direction);
                    newPlots.Add(subPlots[0]);
                    newPlots.Add(subPlots[1]);
                    overMaxSize = true;
                } else if (plot.width > maxSize)
                {
                    List<RectInt> subPlots = splitPlot(plot, 0);
                    newPlots.Add(subPlots[0]);
                    newPlots.Add(subPlots[1]);
                    overMaxSize = true;
                } else if (plot.height > maxSize)
                {
                    List<RectInt> subPlots = splitPlot(plot, 1);
                    newPlots.Add(subPlots[0]);
                    newPlots.Add(subPlots[1]);
                    overMaxSize = true;
                } else
                {
                    newPlots.Add(plot);
                }

            }
            plots = newPlots;
        }
        if (DisplayPlots)
        {
            DebugPlots(plots);
        }
        return plots;
    }

    private List<RectInt> splitPlot(RectInt plot, int direction)
    {
        if (direction == 0)
        {
            if (minSize > plot.width - minSize) { return null; }
            int width = Random.Range(minSize, plot.width - minSize);
            RectInt leftRect = new RectInt(plot.x, plot.y, width, plot.height);
            RectInt rightRect = new RectInt(plot.x + width, plot.y, plot.width - width, plot.height);
            
            return new List<RectInt> { leftRect, rightRect };

        }
        else if (direction == 1)
        {
            if (minSize > plot.height - minSize) { return null; }
            int height = Random.Range(minSize, plot.height - minSize);
            RectInt bottomRect = new RectInt(plot.x, plot.y, plot.width, height);
            RectInt topRect = new RectInt(plot.x, plot.y + height, plot.width, plot.height - height);
            
            return new List<RectInt> { bottomRect, topRect};
        }

        return null;
        
    }
    private void DebugPlots(List<RectInt> plots)
    {
        GameObject plotDebugger = new GameObject("PlotDebugger");
        foreach (RectInt rect in plots) {
            GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            quad.transform.SetParent(plotDebugger.transform);
            quad.transform.rotation = Quaternion.Euler(90, 0, 0);
            quad.transform.localScale = new Vector3(rect.width, rect.height, 1f);
            quad.transform.position = new Vector3(rect.center.x, 0f, rect.center.y);
            quad.GetComponent<Renderer>().material.color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        }
    }
} 
