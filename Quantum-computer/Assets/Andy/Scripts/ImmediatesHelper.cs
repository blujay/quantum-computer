using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class C
{

    public static Camera Cam
    {
        get { return Camera.main; }
    }

    public static Vector3 CamPos
    {
        get { return Cam.transform.position; }
        set { CamPos = value; }
    }

    public static void MoveCam(float x, float y, float z)
    {
        CamPos = CamPos + new Vector3(x, y, z);
    }

    public static float TimeScale
    {
        get { return Time.timeScale; }
        set { Time.timeScale = value; }
    }

    public static List<Station> Stations
    {
        get
        {
            var m = Object.FindObjectOfType<StationManager>();
            return m.Stations.ToList();
        }
    }
}