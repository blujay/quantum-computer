using UnityEngine;

public class StationManager : MonoBehaviour
{

    public Station[] Stations;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        foreach (var station in Stations)
        {
            station.CenterMarker = transform;
        }
    }
}
