using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Station : MonoBehaviour
{
    public Transform CenterMarker;
    public List<Slot> SlotList;

    public Slot GetFirstFreeSlot()
    {
        var firstFreeSlot = SlotList.FirstOrDefault(x => x.IsFilled() == false);
        return firstFreeSlot;
    }

    public Slot GetLastFilledSlot()
    {
        return SlotList.LastOrDefault(x => x.IsFilled() == true);
    }

    public Slot PushIon(IonController ion)
    {
        var freeSlot = GetFirstFreeSlot();
        freeSlot.Ion = ion;
        return freeSlot;
    }

    public IonController PopIon()
    {
        var filledSlot = GetLastFilledSlot();
        if (filledSlot != null)
        {
            var ion = filledSlot.Ion;
            filledSlot.Ion = null;
            return ion;
        }
        else
        {
            return null;
        }
    }

    public bool HasFreeSlot()
    {
        return GetFirstFreeSlot() != null;
    }

    public void SendTo(Station destinationStation)
    {
        var ion = PopIon();
        if (destinationStation.HasFreeSlot())
        {
            var destinationSlot = destinationStation.PushIon(ion);
            ion.AnimateTo(destinationSlot);
        };
    }



    [ContextMenu("Send to 1")]
    public void SendTo1()
    {
        SendTo(FindObjectOfType<StationManager>().Stations[0]);
    }

    [ContextMenu("Send to 2")]
    public void SendTo2()
    {
        SendTo(FindObjectOfType<StationManager>().Stations[1]);
    }

    [ContextMenu("Send to 3")]
    public void SendTo3()
    {
        SendTo(FindObjectOfType<StationManager>().Stations[2]);
    }

    [ContextMenu("Send to 4")]
    public void SendTo4()
    {
        SendTo(FindObjectOfType<StationManager>().Stations[3]);
    }

}