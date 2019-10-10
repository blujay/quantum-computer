using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entangler2 : MonoBehaviour
{

    public GameObject Ion1;
    public GameObject Ion2;

    private LineRenderer lr;
    public int Segments = 10;
    public float width = 0.02f;

    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.startWidth = width;
        lr.endWidth = width;
        lr.positionCount = Segments;
    }

    void Update()
    {
        var i1 = Ion1.transform.position;
        var i2 = Ion2.transform.position;
        var vec = i2 - i1;
        for (int i = 0; i < Segments - 1; i+=2)
        {
            var pos = Vector3.Lerp(i1, i2, (float) i / Segments);
            var nextPos = Vector3.Lerp(i1, i2, ((float) (i + 1)) / Segments);
            //var foo = new Plane(vec, vec.magnitude);
            lr.SetPosition(i, pos + (vec * Mathf.PerlinNoise(pos.x, pos.y)));
            lr.SetPosition(i+1, nextPos + (Mathf.PerlinNoise(nextPos.x, nextPos.y) * vec));

        }
    }
}
