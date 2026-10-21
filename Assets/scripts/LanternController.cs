using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public Light lanternaLight;
    public KeyCode teclaLigarDesligar = KeyCode.F;

    void Start()
    {
        if (lanternaLight == null)
        {
            lanternaLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaLigarDesligar))
        {
            lanternaLight.enabled = !lanternaLight.enabled; 
        }
    }
}
