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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetToShoot.transform);
        StartCoroutine(Tir());
    }


    IEnumerator Tir()
    {
        if (targetToShoot != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            Vector3 direction = (targetToShoot.transform.position - transform.position).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 4f;
            yield return new WaitForSeconds(intervalleTir);
        }
    }

    
}
