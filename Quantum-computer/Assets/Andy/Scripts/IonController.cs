using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonController : MonoBehaviour
{
    public Station CurrentStation;
    public Station DestinationStation;
    public float progress;
    public float speed = 0.01f;
    public AnimationCurve curve;

    private Vector3 Startpoint;
    private Vector3 Midpoint;
    private Vector3 Endpoint;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        var slot = CurrentStation.GetFirstFreeSlot();
        transform.position = slot.transform.position;
        CurrentStation.PushIon(this);
    }

    void Update()
    {
        if (CurrentStation == null || DestinationStation == null) return;
        if (progress > 1f)
        {
            CurrentStation = DestinationStation;
            DestinationStation = null;
            progress = 0;
            return;
        }

        Vector3 currentStartpoint;
        Vector3 currentDestination;
        float currentProgress;

        progress += speed;
        if (progress <= 0.5)
        {
            currentDestination = Midpoint;
            currentStartpoint = Startpoint;
            currentProgress = curve.Evaluate(progress * 2f);
        }
        else
        {
            currentDestination = Endpoint;
            currentStartpoint = Midpoint;
            currentProgress = curve.Evaluate((progress - 0.5f) * 2f);
        }

        transform.position = Vector3.Lerp(currentStartpoint, currentDestination, currentProgress);
    }

    public void AnimateTo(Slot slot)
    {
        var station = slot.GetComponentInParent<Station>();
        Startpoint = transform.position;
        Midpoint = station.CenterMarker.position;
        Endpoint = slot.transform.position;
        DestinationStation = station;
        progress = 0;
    }

}
