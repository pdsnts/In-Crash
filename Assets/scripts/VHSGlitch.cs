using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSGlitch : MonoBehaviour
{
    public float glitchAmount = 0.02f;
    public float glitchSpeed = 5f;

    float timer;

    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        timer += Time.deltaTime * glitchSpeed;

        float noiseX = Mathf.PerlinNoise(timer, 0f) - 0.5f;
        float noiseY = Mathf.PerlinNoise(0f, timer) - 0.5f;

        transform.localPosition = originalPos + new Vector3(noiseX, noiseY, 0f) * glitchAmount;
    }

    public void SetGlitch(float amount)
    {
        glitchAmount = amount;
    }
}