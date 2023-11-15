using UnityEngine;

public class MeteoriteGenerator : MonoBehaviour
{
    public GameObject meteoritePrefab;
    public float spawnRate = 1f;
    public float spawnRadius = 10f;
    public float meteoriteSpeed = 1f; // Nouvelle variable pour définir la vitesse des météorites

    void Start()
    {
        InvokeRepeating("SpawnMeteorite", 0f, 1f / spawnRate);
    }

    void SpawnMeteorite()
    {
        Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPosition.x, transform.position.y, randomPosition.y);

        // Instanciez la météorite à la position générée
        GameObject meteorite = Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);

        // Ajoutez un composant Rigidbody à la météorite
        Rigidbody meteoriteRigidbody = meteorite.AddComponent<Rigidbody>();

        // Définissez la vitesse initiale de la météorite
        meteoriteRigidbody.velocity = new Vector3(0f, 0f, -meteoriteSpeed); // Ajustez selon vos besoins
    }
}
