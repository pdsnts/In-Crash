using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaInteração : MonoBehaviour
{
   [Header("Configurações da Porta")]
    [Tooltip("Ângulo da porta quando está aberta")]
    public float anguloAberta = 90f;
    
    [Tooltip("Ângulo da porta quando está fechada")]
    public float anguloFechada = 0f;
    
    [Tooltip("Velocidade da animação")]
    public float velocidade = 2f;

    private bool estaAberta = false;
    private bool animando = false;

    // O Unity chama essa função automaticamente quando você clica no objeto com o rato
    // (Requer um Collider no objeto)
    void OnMouseDown()
    {
        Interagir();
    }

    // Função pública que você também pode chamar a partir de um script de Raycast do Jogador
    public void Interagir()
    {
        if (!animando)
        {
            estaAberta = !estaAberta;
            StartCoroutine(AnimarPorta(estaAberta ? anguloAberta : anguloFechada));
        }
    }

    IEnumerator AnimarPorta(float anguloAlvo)
    {
        animando = true;
        
        // Pega a rotação atual e calcula a rotação final desejada
        Quaternion rotacaoInicial = transform.localRotation;
        Quaternion rotacaoFinal = Quaternion.Euler(transform.localEulerAngles.x, anguloAlvo, transform.localEulerAngles.z);
        
        float tempo = 0f;

        // Interpola suavemente entre a rotação atual e a final
        while (tempo < 1f)
        {
            tempo += Time.deltaTime * velocidade;
            transform.localRotation = Quaternion.Slerp(rotacaoInicial, rotacaoFinal, tempo);
            yield return null; // Espera até o próximo frame
        }

        animando = false;
    }
}
