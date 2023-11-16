using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienBoss : MonoBehaviour
{
    public GameObject targetToShoot;
    sampleTest refToTarget;
    public GameObject projectilePrefab;
    public float intervalleTir = 2f;

    void Start()
    {
        refToTarget = targetToShoot.GetComponent<sampleTest>();
        StartCoroutine(Tir());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetToShoot.transform);
    }


    IEnumerator Tir()
    {
        while (true)
        {
            Tirer();
            yield return new WaitForSeconds(intervalleTir);
        }
    }

    void Tirer()
    {
        if (targetToShoot != null)
        {
            // Créer le projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Ajouter une force au projectile pour qu'il se déplace vers la cible
            Vector3 direction = (targetToShoot.transform.position - transform.position).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 4f;
        }
    }
}
