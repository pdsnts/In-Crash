using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
   [Header("Configurações do Prefab")]
    [Tooltip("O prefab da árvore a ser instanciado")]
    public GameObject treePrefab;

    [Header("Área de Geração")]
    [Tooltip("Centro da área onde as árvores serão geradas")]
    public Vector3 centerPos = Vector3.zero;
    [Tooltip("Tamanho da área (largura e profundidade)")]
    public Vector2 areaSize = new Vector2(20f, 20f);
    
    [Header("Configurações das Árvores")]
    [Tooltip("Número de árvores a serem geradas")]
    public int numberOfTrees = 30;
    
    [Tooltip("Tamanho mínimo da árvore")]
    public float minScale = 1.1f;
    [Tooltip("Tamanho máximo da árvore")]
    public float maxScale = 2.1f;

    void Start()
    {
        GerarArvores();
    }

    public void GerarArvores()
    {
        if (treePrefab == null)
        {
            Debug.LogError("O prefab da árvore não foi atribuído!");
            return;
        }

        GameObject parentObject = new GameObject("Arvore");
        
        for (int i = 1; i <= numberOfTrees; i++)
        {
            float randomX = Random.Range(-areaSize.x / 2f, areaSize.x / 2f);
            float randomZ = Random.Range(-areaSize.y / 2f, areaSize.y / 2f);
            Vector3 randomPosition = centerPos + new Vector3(randomX, 0f, randomZ);

            GameObject newTree = Instantiate(treePrefab, randomPosition, Quaternion.identity);

            float randomYRotation = Random.Range(0f, 360f);
            newTree.transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);

            float randomScale = Random.Range(minScale, maxScale);
            newTree.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            
            newTree.name = "tree_" + i;

            newTree.transform.SetParent(parentObject.transform);
        }
    }
}
