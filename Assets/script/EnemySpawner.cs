using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // le prefab que vous voulez faire apparaître
    public int numberOfPrefabs = 10; // le nombre de prefabs à faire apparaître
    public float spawnRadius = 10f; // le rayon dans lequel les prefabs seront générés

    void Start()
    {
        // Appelez la fonction pour faire apparaître les prefabs lors du démarrage du jeu
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Générer une position aléatoire dans un cercle défini par spawnRadius
            Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
            Debug.Log(randomPosition);
            // Convertir la position 2D en 3D en utilisant la position Y actuelle du SpawnManager
            Vector3 spawnPosition = new Vector3(randomPosition.x, transform.position.y, 0);
            Debug.Log(spawnPosition);
            
            // Instancier le prefab à la position générée
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
