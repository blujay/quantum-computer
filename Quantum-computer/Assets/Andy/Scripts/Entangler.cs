using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entangler : MonoBehaviour
{

    public GameObject Ion1;
    public GameObject Ion2;

    private TrailRenderer tr;
    private LineRenderer lr;

    public Station station;
    public float frequency = 5f;
    public float wiggle = 0.1f;
    public float wiggleAmount = 1f;

    void Start()
    {
        //station = GetComponent<Station>();
        tr = gameObject.GetComponent<TrailRenderer>();
        lr = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Ion1 == null || Ion2 == null)
        {
            tr.emitting = false;
            lr.enabled = false;
            return;
        }

        tr.emitting = true;
        lr.enabled = true;

        lr.SetPosition(0, Ion1.transform.position);
        lr.SetPosition(1, Ion2.transform.position);

        float progress = (Mathf.Sin(Time.time * frequency) + 1f) / 2f;
        float foo = Mathf.PerlinNoise(transform.position.x, transform.position.y) * (wiggle * Mathf.Sin(Time.time));
        var newpos = Vector3.Lerp(Ion1.transform.position, Ion2.transform.position, progress);
        var vector = transform.position - newpos;
        newpos += Vector3.Cross(vector, Vector3.up) * (foo * wiggleAmount);
        transform.position = newpos;
    }

    [ContextMenu("Entangle On")]
    public void EntangleOn()
    {
        Ion1 = station.SlotList[0].Ion.gameObject;
        Ion2 = station.SlotList[1].Ion.gameObject;
    }

    [ContextMenu("Entangle Off")]
    public void EntangleOff()
    {
        Ion1 = null;
        Ion2 = null;
    }

    [ContextMenu("Entangle Test")]
    public void EntangleTest()
    {
        var ions = FindObjectsOfType<IonController>();
        Ion1 = ions[0].gameObject;
        Ion2 = ions[1].gameObject;
    }

}
