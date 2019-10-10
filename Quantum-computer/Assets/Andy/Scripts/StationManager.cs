using UnityEngine;

public class StationManager : MonoBehaviour
{

    public Station[] Stations;

    void Start()
    {
        foreach (var station in Stations)
        {
            station.CenterMarker = transform;
        }
    }
}
