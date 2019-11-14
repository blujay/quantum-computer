using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{

    private PlayableDirector director;
    private Entangler entangler;
    private StationManager stationManager;
    private bool IsPlaying = true;

    void Start()
    {
        stationManager = FindObjectOfType<StationManager>();
        entangler = FindObjectOfType<Entangler>();
        director = gameObject.GetComponent<PlayableDirector>();
    }

    public void Reset()
    {
        director.time = 0;
        director.Play();
        IsPlaying = true;
        entangler.Ion1 = null;
        entangler.Ion2 = null;
        stationManager.Reset();
        var ions = FindObjectsOfType<IonController>();
        foreach (var station in stationManager.Stations)
        {
            foreach (var slot in station.SlotList)
            {
                slot.Ion = null;
            }
        }
        for (var i = 0; i < ions.Length; i++)
        {
            var slot = stationManager.Stations[0].SlotList[i];
            slot.Ion = ions[i];
            ions[i].AnimateTo(slot);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) Reset();

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            IsPlaying = !IsPlaying;
//            if (IsPlaying)
//            {
//                director.Play();
//            }
//            else
//            {
//                director.Pause();
//            }
//        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            director.time = 60f;
            director.Play();
        }
    }
}
