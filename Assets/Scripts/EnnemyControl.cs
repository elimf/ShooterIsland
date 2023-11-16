using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyControl : MonoBehaviour
{
    private Vector2 movement;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    bool fired = false;
    public GameObject targetFrom;
    public float shootTimer = 1;
    public float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-MovementSpeed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 positionClic = Input.mousePosition;

        Vector3 positionDansScene = Camera.main.ScreenToWorldPoint(positionClic);
        Debug.Log(positionDansScene);

        shootTimer = shootTimer - Time.deltaTime;
        if (shootTimer < 0 && fired == false)
        {
            fired = true;
            GameObject BulletInstance = Instantiate(BulletPrefab);
            BulletInstance.transform.SetParent(transform.parent);
            BulletInstance.transform.position = new Vector3(transform.position.x + 2.10f, transform.position.y, transform.position.z);
            BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3((positionDansScene.x - transform.position.x) + positionDansScene.y + 3 - transform.position.y + 6, 0);

            Destroy(BulletInstance.gameObject, 5);
            shootTimer = 1;
        }
        else
        {
            fired = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

/*
*/