using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entangler : MonoBehaviour
{

    public GameObject Ion1;
    public GameObject Ion2;

    private TrailRenderer tr;
    public bool enabled;
    public float frequency = 5f;
    public float wiggle = 0.1f;
    public float wiggleAmount = 1f;

    void Start()
    {
        tr = gameObject.GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (!enabled) return;
        float progress = (Mathf.Sin(Time.time * frequency) + 1f) / 2f;
        float foo = Mathf.PerlinNoise(transform.position.x, transform.position.y) * (wiggle * Mathf.Sin(Time.time));
        var newpos = Vector3.Lerp(Ion1.transform.position, Ion2.transform.position, progress);
        var vector = transform.position - newpos;
        newpos += Vector3.Cross(vector, Vector3.up) * (foo * wiggleAmount);
        transform.position = newpos;
    }
}
