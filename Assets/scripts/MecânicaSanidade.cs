using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecânicaSanidade : MonoBehaviour
{
    [Header("Referências")]
    public VHSGlitch scriptDaCamera; // Arraste a Câmera Principal para este campo no Inspector

    [Header("Configurações do Susto")]
    public float intensidadeDoSusto = 0.5f; // Força do tremor durante o susto
    public float tempoDeRecuperacao = 1.5f; // Quanto tempo a câmera treme
    public float glitchBase = 0.01f; // O valor normal de glitch do seu script original

    private bool jaAtivado = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o Player e impede que o susto repita infinitamente
        if (other.CompareTag("Player") && !jaAtivado)
        {
            jaAtivado = true;
            StartCoroutine(EfeitoSusto());
        }
    }

    private IEnumerator EfeitoSusto()
    {
        // Aplica o tremor intenso simulando o choque/perda de sanidade
        scriptDaCamera.SetGlitch(intensidadeDoSusto);

        // Aguarda a duração do evento
        yield return new WaitForSeconds(tempoDeRecuperacao);

        // Retorna a câmera para o balanço suave original
        scriptDaCamera.SetGlitch(glitchBase);
    } 
}
