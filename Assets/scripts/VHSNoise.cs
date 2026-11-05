using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSNoise : MonoBehaviour
{
    public float noiseIntensity = 0.02f;
    public float glitchSpeed = 10f;

    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        float x = Mathf.PerlinNoise(Time.time * glitchSpeed, 0f) - 0.5f;
        float y = Mathf.PerlinNoise(0f, Time.time * glitchSpeed) - 0.5f;

        transform.localPosition = originalPos + new Vector3(x, y, 0f) * noiseIntensity;
    }
}