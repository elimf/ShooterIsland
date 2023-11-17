using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AlienBoss : MonoBehaviour
{
    public GameObject targetToShoot;
    public GameObject projectilePrefab;
    public float intervalleTir = 2f;
    private int[] tabPointLife = new int[1001];
    int indexLife = 0;

    public StateStarShip stateEnemy = new StateStarShip();

    public GameObject portail;




    void Start()
    {
        for (int i = 0; i <= 1000; i++)
    {
        tabPointLife[i] = 1000 - i;
    }

        StartCoroutine(Tir());
        //portail = GameObject.FindWithTag("SceneEnd");
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
        if(collision.gameObject.tag == "Limit"){
            return;
        }
        takeDommage();
    }

    public void takeDommage()
    {
        indexLife += 10;
        Debug.Log(indexLife);
        Debug.Log(tabPointLife.Length - 1);
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
        GameObject projectile = Instantiate(projectilePrefab, (transform.position + Vector3.left * 5f), Quaternion.identity);

        Vector3 direction = (targetToShoot.transform.position - transform.position).normalized;

        projectile.GetComponent<Rigidbody2D>().velocity = direction * 15f;
    }
}