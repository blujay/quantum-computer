using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonColor : MonoBehaviour
{

    public float HueFrequency = 1f;
    public float Opacity = 0.9f;
    public float HueRange = 200f;
    public float HueOffset = 1f;

    public Color color;
    public MeshRenderer quad;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        color =  Color.HSVToRGB((Mathf.Sin(Time.time * (HueFrequency + Random.value/3f)) + 1f) / HueRange + HueOffset, .8f, .8f);
        color.a = Opacity;
        quad.material.SetColor("_TintColor", color);
    }
}
