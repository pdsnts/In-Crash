using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecânicaSanidade : MonoBehaviour
{
    [Header("Referências")]
    public VHSGlitch scriptDaCamera;

    [Header("Configurações do Susto")]
    public float intensidadeDoSusto = 0.5f;
    public float tempoDeRecuperacao = 1.5f; 
    public float glitchBase = 0.01f;

    private bool jaAtivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !jaAtivado)
        {
            jaAtivado = true;
            StartCoroutine(EfeitoSusto());
        }
    }

    private IEnumerator EfeitoSusto()
    {
        scriptDaCamera.SetGlitch(intensidadeDoSusto);

        yield return new WaitForSeconds(tempoDeRecuperacao);

        scriptDaCamera.SetGlitch(glitchBase);
    } 
}
