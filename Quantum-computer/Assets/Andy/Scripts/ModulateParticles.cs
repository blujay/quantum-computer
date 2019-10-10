using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulateParticles : MonoBehaviour
{

    private ParticleSystem ps;
    public float Frequency = 10f;
    public float Amplitude = 10f;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var vel = ps.velocityOverLifetime;
        vel.orbitalX = Mathf.Sin(Time.time * Frequency) * Amplitude;
        vel.orbitalY = Mathf.Cos(Time.time * Frequency) * Amplitude;
        vel.orbitalZ = Mathf.Sin(Time.time * Frequency * 0.5f) * Amplitude;
    }
}
