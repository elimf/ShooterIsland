using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AlienBoss : MonoBehaviour
{
    public GameObject targetToShoot;
    public GameObject projectilePrefab;
    public float intervalleTir = 2f;
    private int[] tabPointLife = new int[] { 100, 95, 90, 85, 80, 75,70,65,60,55,50,45,40,35,30,25,20,15,10,5, 0 };
    int indexLife = 0;

    public StateStarShip stateEnemy = new StateStarShip();

    GameObject portail;




    void Start()
    {
        StartCoroutine(Tir());
        portail = GameObject.FindWithTag("SceneEnd");
        stateEnemy.setPointLife(indexLife);
    }

    void Update()
    {
        // transform.LookAt(targetToShoot.transform);
    }

    IEnumerator Tir()
    {
        while (true) 
        {
            if (targetToShoot != null)
            {
                Tirer();
            }

            yield return new WaitForSeconds(intervalleTir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        takeDommage();
    }

    public void takeDommage()
    {
        indexLife += 1;
        if (indexLife == tabPointLife.Length - 1)
        {
            gameObject.SetActive(false);
            portail.SetActive(true);
            return;
        }
        stateEnemy.setPointLife(tabPointLife[indexLife]);
       
    }

    void Tirer()
    {
        GameObject projectile = Instantiate(projectilePrefab, (transform.position + Vector3.left * 2f), Quaternion.identity);

        Vector3 direction = (targetToShoot.transform.position - transform.position).normalized;

        projectile.GetComponent<Rigidbody2D>().velocity = direction * 15f;
    }
}