using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    private void Awake()
    {
        points = new Transform[transform.childCount]; // array's length
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); // get through every child
        }
    }

}
