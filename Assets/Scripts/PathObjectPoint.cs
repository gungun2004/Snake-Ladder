using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PathObjectPoint :PathPoint
{
    public PathPoint[] CommonPathPoint;
    public PathPoint[] RedPathPoint;
    public PathPoint[] YellowPathPoint;
    public PathPoint[] GreenPathPoint;
    public PathPoint[] BluePathPoint;
    [Header("Scale and positning Difference")]
    public float[] scales;
    public float[] positionDifference;
    public PathPoint[] BasePoint;
    public List<PathPoint> SafePoint;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
