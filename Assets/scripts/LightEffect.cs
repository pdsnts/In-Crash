using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LuzPiscante : MonoBehaviour
{
    private Light luz;
    
    [Header("Configurações de Tempo")]
    public float tempoLigada = 0.3f;
    public float tempoDesligada = 0.2f;

    void Start()
    {
        luz = GetComponent<Light>();
        
        StartCoroutine(PiscarLuz());
    }

    IEnumerator PiscarLuz()
    {
        while (true)
        {
            luz.enabled = true;
            yield return new WaitForSeconds(tempoLigada);
            
            luz.enabled = false;
            yield return new WaitForSeconds(tempoDesligada);
        }
    }
}
