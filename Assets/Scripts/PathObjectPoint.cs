using UnityEngine;

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

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
